using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views;

public partial class MainPage : DemoPage {
    public ICommand NavigationCommand { get; }
    private bool inNavigation;
    private ThemesPage themesPage;

    public MainPage() {
        InitializeComponent();
        NavigationCommand = new Command<Models.DemoItem>(async (obj) => await NavigateToDetailsPageAsync(obj.Module));
        themesPage = new ThemesPage();
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
        await DemoNavigationService.NavigateToPage(detailsPage, data.Title);
        inNavigation = false;
    }

    public async void DemoItemTappedControlShortcut(object sender, EventArgs e) {
        if (inNavigation)
            return;

        inNavigation = true;
        if (sender is DXButton dxButton) {
            var demoItem = (DemoItem)dxButton.BindingContext;
            await DemoNavigationService.NavigateToDemo(demoItem);
        }
        inNavigation = false;
    }

    private async void Theme_Tapped(object sender, EventArgs e) {
        await DemoNavigationService.NavigateToPage(themesPage);
    }
}