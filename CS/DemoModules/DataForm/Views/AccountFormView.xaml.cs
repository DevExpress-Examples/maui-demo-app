using System;
using DemoCenter.Maui.DemoModules.DataForm.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class DataFormAccountFormView : ContentPage {
        public DataFormAccountFormView() {
            InitializeComponent();
            BindingContext = new AccountFormViewModel();
        }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            ((AccountFormViewModel)this.BindingContext).Rotate(dataForm, height > width);
        }

        private void SubmitOnClicked(object sender, EventArgs e) {
            if (dataForm.Validate()) { 
                dataForm.Commit();
                DisplayAlert("Success", "Your account has been created successfully", "OK");
            }
        }
    }
}
