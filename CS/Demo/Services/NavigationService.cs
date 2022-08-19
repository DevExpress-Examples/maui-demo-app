using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Services {
    public static class NavigationService {

        static void SetDemoPageTitleView(Page page, DemoItem demoItem) {
            Label label = new() {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontFamily = "Univia-Pro Medium",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                Text = (demoItem == null)? page.Title : demoItem.Title,
                LineBreakMode = Microsoft.Maui.LineBreakMode.NoWrap
            };
            label.SetDynamicResource(Label.TextColorProperty, "TextThemeColor");

            Grid container = new();
            container.Add(label);

            Shell.SetTitleView(page, container);
        }

        public static async Task NavigateToDemo(DemoItem demoItem) {
            Page demoPage = (Page)Activator.CreateInstance(demoItem.Module);

            await NavigateToPage(demoPage, demoItem);
        }

        public static async Task NavigateToPage(Page page, DemoItem demoItem = null) {
            if (Shell.GetTitleView(page) == null)
                SetDemoPageTitleView(page, demoItem);

            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}

