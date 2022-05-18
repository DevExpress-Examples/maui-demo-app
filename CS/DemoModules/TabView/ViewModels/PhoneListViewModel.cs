using System.Collections.Generic;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Core.Themes;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.ViewModels {
    public class PhoneListViewModel : NavigationViewModelBase {
        GroupedPhoneList selectedItem;
        readonly PhoneList phoneList;
        PhoneListData alphabeticalyPhoneListData;
        PhoneListData categoryPhoneListData;
        GroupParameterName currentGroupParameter;

        public PhoneListData PhoneListData => currentGroupParameter == GroupParameterName.Alphabeticaly? alphabeticalyPhoneListData: categoryPhoneListData;
        public GroupParameterName GroupParameter => currentGroupParameter;
        public bool IsLightTheme { get { return ThemeManager.ThemeName == Theme.Light; } }
        public PhoneListViewModel() {
            phoneList = XmlDataDeserializer.GetData<PhoneList>("Resources.PhoneListData.xml");
            alphabeticalyPhoneListData = GroupByParameter(GroupParameterName.Alphabeticaly);
            categoryPhoneListData = GroupByParameter(GroupParameterName.Category);
            currentGroupParameter = GroupParameterName.Alphabeticaly;
        }
        public void SetGroupByParameter(GroupParameterName parameter) {
            ResetSelectedItem(null);
            currentGroupParameter = parameter;
        }
        PhoneListData GroupByParameter(GroupParameterName parameter) {
            Dictionary<string, PhoneList> result = new Dictionary<string, PhoneList>();
            result.Add("All", phoneList);
            foreach(Contact contact in phoneList) {
                string groupedValue = GetGroupedValue(contact, parameter);
                if (!result.ContainsKey(groupedValue)) {
                    result.Add(groupedValue, new PhoneList());
                }
                result[groupedValue].Add(contact);
            }
            PhoneListData phoneListData = new PhoneListData(result.Count);
            foreach(string group in result.Keys) {
                GroupedPhoneList groupedList = new GroupedPhoneList() { Contacts = result[group], GroupName = group };
                if(GetShowGroupIcon(parameter)) {
                    groupedList.ShowGroupIcon = true;
                    groupedList.GroupIconSource = GetGroupIconSource(group);
                }
                phoneListData.Add(groupedList);
            }
            return phoneListData;
        }
        string GetGroupedValue(Contact contact, GroupParameterName parameter) {
            if (parameter == GroupParameterName.Alphabeticaly)
                return contact.LastName[0].ToString();
            else
                return contact.ContactCategory.ToString();
        }
        public GroupedPhoneList SelectedItem {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value, onChanged: (oldValue, newValue) => {
                ResetSelectedItem(oldValue);
                if(newValue != null) newValue.IsSelected = true;
            });
        }
        void ResetSelectedItem(GroupedPhoneList oldValue) {
            if (oldValue != null) {
                oldValue.IsSelected = false;
            } else {
                foreach(GroupedPhoneList curentItem in PhoneListData) {
                    if(curentItem.IsSelected) {
                        curentItem.IsSelected = false;
                        return;
                    }
                }
            }
        }
        ImageSource GetGroupIconSource(string groupName) {
            switch(groupName) {
                case "Star": return ImageSource.FromFile("demotabview_star");
                case "Work": return ImageSource.FromFile("demotabview_work");
                case "Family": return ImageSource.FromFile("demotabview_family");
                case "All": return ImageSource.FromFile("demotabview_all");
                default:
                    return string.Empty;
            }
        }
        bool GetShowGroupIcon(GroupParameterName parameter) {
            return parameter == GroupParameterName.Category;
        }
    }
}
