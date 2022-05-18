using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;
using DemoCenter.Maui.Data;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Services;

namespace DemoCenter.Maui.ViewModels {
    public class MainViewModel : BaseViewModel {
        string version;
        public string ProductTitle => "DevExpress.Maui.DemoCenter";
        public string Version => this.version;
        public string ProductUrl => "https://www.devexpress.com/maui/";
        public string DocumentationUrl => "https://docs.devexpress.com/MAUI/";
        public string SourceCodeUrl => "https://github.com/DevExpress-Examples/maui-demo-app";
        public ICommand OpenWebCommand { get; }
        void InitVersion() {
            Version assemblyVersion = Assembly.GetAssembly(GetType()).GetName().Version;
            this.version = $"{assemblyVersion.Major}.{assemblyVersion.Minor}.{assemblyVersion.Build}";
        }
        public string TitleText => "DevExpress Mobile UI";
        public string SubTitle => "for Maui";
        public List<DemoItem> Items => GetItems();
        public IList<MenuItemDescription> MenuItems { get; }
        public ICommand NavigationControlCommand { get; }
        public ICommand NavigationDemoCommand { get; }
        public string Description { get; } = "This application demonstrates DevExpress components that help you create business solutions for the .NET MAUI platform\n\n .NET MAUI is a trademark or registered trademark of Microsoft Corporation";

        readonly MauiUriOpener openService;

        public MainViewModel() {
            InitVersion();
            this.openService = new MauiUriOpener();
            OpenWebCommand = new DelegateCommand<MenuItemDescription>((p) => this.openService.Open(p.Url));
            MenuItems = new List<MenuItemDescription> {
                new MenuItemDescription("Product Page", "productpage", OpenWebCommand, ProductUrl),
                new MenuItemDescription("Documentation", "documentation", OpenWebCommand, DocumentationUrl),
                new MenuItemDescription("Source Code", "sourcecode", OpenWebCommand, SourceCodeUrl)
            };
        }

        List<DemoItem> GetItems() {
            List<DemoItem> result = new List<DemoItem>();
            result.AddRange(DemoGroupsData.DemoItems);
            return result;
        }
    }

    public record MenuItemDescription(string Name, string Icon, ICommand Command, string Url);
}
