
using System;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;
using DemoCenter.Maui.Services;

namespace DemoCenter.Maui.Views {
    public partial class SettingsForm : Demo.DemoPage {
        public SettingsForm() {
            InitializeComponent();
        }

        async void OnBioTap(object sender, EventArgs e) {
            await NavigationService.NavigateToPage(new EditBioPage() { Settings = (SettingsFormViewModel)BindingContext });
        }
    }
}
