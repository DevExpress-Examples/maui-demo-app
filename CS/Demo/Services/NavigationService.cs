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

        static void SetDemoPageTitleView(Page demoPage, DemoItem demoItem) {
            Label label = new() {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                FontFamily = "Univia-Pro Medium",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.Transparent,
                Text = demoItem.Title,
                LineBreakMode = Microsoft.Maui.LineBreakMode.NoWrap
            };
            label.SetDynamicResource(Label.TextColorProperty, "TextThemeColor");

            Grid container = new();
            container.Add(label);

            Shell.SetTitleView(demoPage, container);
        }

        public static async Task NavigateToDemo(DemoItem demoItem) {
            Page demoPage = (Page)Activator.CreateInstance(demoItem.Module);
            if (Shell.GetTitleView(demoPage) == null)
                SetDemoPageTitleView(demoPage, demoItem);

            await Shell.Current.Navigation.PushAsync(demoPage);
        }
    }
}

