using System;
using DevExpress.Maui.Controls;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.CollectionView.Data;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class ContactsCRUDView : Demo.DemoPage {
        #region Nested
        public class MyStringLoader : Localizer.IStringLoader {
            public bool TryGetString(string key, out string value) {
                if (key == "CollectionViewStringId.GroupCaptionDisplayFormat") {
                    value = "{1}";
                    return true;
                }

                value = null;
                return false;
            }
        }
        #endregion

        bool inNavigation;

        public ContactsCRUDView() {
            InitializeComponent();
            DBContactService.Instance = new DBContactService(Path.Combine(FileSystem.CacheDirectory, "contacts.db"));
            DBContactService.Instance.InitCache();
            BindingContext = new ContactsCRUDViewModel();
            Localizer.StringLoader = new MyStringLoader();
        }

        void ItemClick(object sender, EventArgs e) {
            if (this.inNavigation)
                return;
            this.inNavigation = true;
            Contact clickedContact = (Contact)((SimpleButton)sender).BindingContext;
            this.collectionView.ShowDetailForm(this.collectionView.FindItemHandle(clickedContact), true);
        }
        void AddButtonClick(object sender, EventArgs e) {
            if (this.inNavigation)
                return;
            this.inNavigation = true;
            this.collectionView.ShowDetailNewItemForm(true);
        }
        void SearchTextChanged(object sender, EventArgs e) {
            string searchText = ((TextEdit)sender).Text;
            this.collectionView.FilterString =
                $"Contains([FirstName], '{searchText}') or Contains([LastName], '{searchText}')";
        }

        async void OnDetailFormShowing(object sender, DetailFormShowingEventArgs e) {
            e.Cancel = true;

            if (e.Content is ContactEditingPage contactEditingPage) {
                if (e.DetailFormType == DetailFormType.Edit)
                    contactEditingPage.Title = "Edit contact";
                else if (e.DetailFormType == DetailFormType.New) {
                    contactEditingPage.Title = "Add new contact";
                    contactEditingPage.HideImage();
                }
            }

            await NavigationService.NavigateToPage((Page)e.Content);
        }
        async void OnValidateAndSave(object sender, ValidateItemEventArgs e) {
            try {
                if (e.DataChangeType == DataChangeType.Add) {
                    DBContactService.Instance.InsertRecord(e.Item);
                } else if (e.DataChangeType == DataChangeType.Edit) {
                    DBContactService.Instance.UpdateRecord(e.Item);
                } else if (e.DataChangeType == DataChangeType.Delete) {
                    DBContactService.Instance.DeleteRecord(e.Item);
                }
            } catch (Exception ex) {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            this.inNavigation = false;
        }
    }
}