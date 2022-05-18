using System;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Controls;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            //TitleViewExtensions.SetIsShadowVisible(this, false);
            

        }
        private void OnInfoClicked(object sender, EventArgs args) {
            //(Application.Current.MainPage as DrawerPage).IsDrawerOpened = true;
        }
        public void DemoItem_TappedControlShortcut(object sender, System.EventArgs e) {
            var groupItemView = (GroupItemView)sender;
            if (BindingContext is MainViewModel viewModel && groupItemView != null) {
                if (viewModel.NavigationDemoCommand != null) {
                    viewModel.NavigationDemoCommand.Execute(groupItemView.BindingContext);
                }
            }
        }
    }
}
