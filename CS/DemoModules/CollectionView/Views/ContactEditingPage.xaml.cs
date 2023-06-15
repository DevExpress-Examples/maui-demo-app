using System;
using DemoCenter.Maui.DemoModules.CollectionView.Data;
using Microsoft.Maui.Controls;
using SQLite;
using System.Net.Mail;
using DevExpress.Maui.Core;


namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class ContactEditingPage : Demo.DemoPage {
        bool isImageVisible = true;

        DetailEditFormViewModel ViewModel => (DetailEditFormViewModel)BindingContext;
        Contact Item => (Contact)ViewModel.Item;

        public ContactEditingPage() {
            InitializeComponent();
            this.image.IsVisible = this.isImageVisible;
        }

        void SaveItemClick(object sender, EventArgs e) {
            if (!this.dataForm.Validate())
                return;
            this.dataForm.Commit();
            ViewModel.Save();
        }
        void OnDataFormValidateProperty(object sender,
            DevExpress.Maui.DataForm.DataFormPropertyValidationEventArgs e) {
            if (e.PropertyName == "Email" && e.NewValue != null) {
                MailAddress res;
                if (!MailAddress.TryCreate((string)e.NewValue, out res)) {
                    e.HasError = true;
                    e.ErrorText = "Invalid email";
                }
            }
        }

        public void HideImage() {
            this.isImageVisible = false;
            if (this.image is not null)
                this.image.IsVisible = false;
        }
    }
}