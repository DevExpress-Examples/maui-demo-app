using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using UIKit;

namespace DemoCenter.Maui.Demo.ThemeLoader {
    internal partial class ThemeEnvironment {
        public async Task<bool> IsLightOperatingSystemTheme() {
            if (UIDevice.CurrentDevice.CheckSystemVersion(12, 0)) {
                UIViewController currentUIViewController = await GetVisibleViewController();

                UIUserInterfaceStyle userInterfaceStyle = currentUIViewController.TraitCollection.UserInterfaceStyle;

                switch (userInterfaceStyle) {
                    case UIUserInterfaceStyle.Light:
                        return true;
                    case UIUserInterfaceStyle.Dark:
                        return false;
                    default:
                        return true;
                }
            } else {
                return true;
            }
        }

        static async Task<UIViewController> GetVisibleViewController() {
            return await Application.Current.Dispatcher.DispatchAsync<UIViewController>(() => {
                UIViewController rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

                UINavigationController navigationController = rootController.PresentedViewController as UINavigationController;
                UITabBarController tabBarController = rootController.PresentedViewController as UITabBarController;

                if (navigationController != null)
                    return navigationController.TopViewController;
                if (tabBarController != null)
                    return tabBarController.SelectedViewController;
                return rootController.PresentedViewController ?? rootController;
            });
        }
    }
}

