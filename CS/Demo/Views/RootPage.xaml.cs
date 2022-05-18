using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DemoCenter.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui {
    public partial class AppShell : Shell {
        public ICommand NavigationCommand { get; }

        public AppShell(){
            InitializeComponent();
            NavigationCommand = new DelegateCommand<Models.DemoItem>(async (obj) => await NavigateToDetailsPageAsync(obj.Module));
        }

        async Task NavigateToDetailsPageAsync(Type demoGroup) {
            IDemoData data = (IDemoData)Activator.CreateInstance(demoGroup);
            Dictionary<string, object> parameters = new Dictionary<string, object> {
                { "DemoData", data }
            };
            ControlPage detailsPage = new ControlPage();
            (detailsPage.BindingContext as ControlViewModel).ApplyQueryAttributes(parameters);
            await Navigation.PushAsync(detailsPage);
        }

        public async void DemoItemTappedControlShortcut(object sender, EventArgs e) {
            if (sender is GroupItemView groupItemView) {
                var demoItem = (DemoItem)groupItemView.BindingContext;
                await NavigationService.NavigateToDemo(demoItem);
            }
        }
    }
}
