
using System;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class AccountFormView : ContentPage {
        readonly AccountFormViewModel viewModel;

        public AccountFormView() {
            InitializeComponent();
            viewModel = new AccountFormViewModel();
            BindingContext = viewModel;
        }

        void OnSubmitClicked(Object sender, EventArgs e) {
            if (viewModel.Validate())
                DisplayAlert("Success", "Your account has been created successfully", "OK");
        }
    }
}
