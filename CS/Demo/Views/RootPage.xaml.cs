using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DemoCenter.Maui.Views;
using DevExpress.Maui.Controls;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    public partial class AppShell : Shell {
        public ICommand NavigationCommand { get; }
        private bool inNavigation = false;

        public AppShell(){
            InitializeComponent();
            BindingContext = new MainViewModel();
            NavigationCommand = new Command<Models.DemoItem>(async (obj) => await NavigateToDetailsPageAsync(obj.Module));
        }

        async Task NavigateToDetailsPageAsync(Type demoGroup) {
            if (inNavigation)
                return;

            inNavigation = true;
            IDemoData data = (IDemoData)Activator.CreateInstance(demoGroup);
            Dictionary<string, object> parameters = new Dictionary<string, object> {
                { "DemoData", data }
            };
            ControlPage detailsPage = new ControlPage();
            (detailsPage.BindingContext as ControlViewModel).ApplyQueryAttributes(parameters);
            await NavigationService.NavigateToPage(detailsPage, data.Title);
            inNavigation = false;
        }

        public async void DemoItemTappedControlShortcut(object sender, EventArgs e) {
            if (inNavigation)
                return;

            inNavigation = true;
            if (sender is SimpleButton simpleButton) {
                var demoItem = (DemoItem)simpleButton.BindingContext;
                await NavigationService.NavigateToDemo(demoItem);
            }
            inNavigation = false;
        }
    }
}
