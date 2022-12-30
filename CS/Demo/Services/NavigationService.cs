using System;
using System.Threading.Tasks;
using DemoCenter.Maui.Models;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Services {
    public static class NavigationService {
        static void SetDemoPageTitleView(Page page, string titleText) {
            Label label = new() {
                FontSize = 17,
                FontFamily = "Roboto Medium",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Margin = 0,
                BackgroundColor = Colors.Transparent,
                Text = titleText,
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
            string titleText = (demoItem == null) ? page.Title : demoItem.Title;
            await NavigateToPage(page, titleText);
        }

        public static async Task NavigateToPage(Page page, string titleText) {
            if (Shell.GetTitleView(page) == null)
                SetDemoPageTitleView(page, titleText);

            await Shell.Current.Navigation.PushAsync(page);
        }
    }
}

