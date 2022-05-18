using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using DemoCenter.Maui.ViewModels;
using DevExpress.Utils;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Data {
    public class PhoneListData : List<GroupedPhoneList> {
        public PhoneListData(int capacity) : base(capacity) {
        }
    }
    public class GroupedPhoneList: NotificationObject {
        bool isSelected;
        public string GroupName { get; set; }
        public ImageSource GroupIconSource { get; set; }
        public bool ShowGroupIcon { get; set; }
        public PhoneList Contacts { get; set; }
        public bool IsSelected {
            get => this.isSelected;
            set => SetProperty(ref this.isSelected, value);
        }
    }

    [XmlRoot(ElementName = "PhoneListData")]
    public class PhoneList : List<Contact> {
    }

    public class Contact {
        Color contactColor = DXColor.Default;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => String.Format("{0} {1}", FirstName, LastName);
        public string Phone { get; set; }
        public string ContactCategory { get; set; }
        public string Initials => FirstName.Substring(0, 1) + LastName.Substring(0, 1);
        public Color CategoryColor => GetContactColor();

        internal Color GetContactColor() {
            if (this.contactColor == DXColor.Default) {
                this.contactColor = ContactColors.GetRandomColor();
            }
            return this.contactColor;
        }
    }
    public class ContactColors {
        public static Color GetRandomColor() {
            return GetColor(new Random().Next(10));
        }

        public static Color GetColor(int colorNumber) {
            switch(colorNumber) {
                case 1: return Color.FromArgb("#f15558");
                case 2: return Color.FromArgb("#ff7c11");
                case 3: return Color.FromArgb("#ffbf22");
                case 4: return Color.FromArgb("#ff6e86");
                case 5: return Color.FromArgb("#9865b0");
                case 6: return Color.FromArgb("#756cfd");
                case 7: return Color.FromArgb("#0055d8");
                case 8: return Color.FromArgb("#01b0ee");
                case 9: return Color.FromArgb("#0097ad");
                case 0: return Color.FromArgb("#00c831");
                default: return Color.FromArgb("#949494");
            }
        }
    }
    public enum GroupParameterName {
        Category,
        Alphabeticaly
    }
}
