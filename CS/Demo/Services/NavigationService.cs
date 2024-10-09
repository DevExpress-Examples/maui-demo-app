using System;
using System.Threading.Tasks;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.Models;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Services {
    public static class DemoNavigationService {
        public static void SetDemoPageTitleView(Page page, string titleText) {
            Shell.SetTitleView(page, new TitleView() { Title = titleText });
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
