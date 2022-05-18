using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
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

        static Task<UIViewController> GetVisibleViewController() {
            TaskCompletionSource<UIViewController> tcs = new TaskCompletionSource<UIViewController>();
            Device.BeginInvokeOnMainThread(() => {
                try {
                    UIViewController rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

                    UINavigationController navigationController = rootController.PresentedViewController as UINavigationController;
                    UITabBarController tabBarController = rootController.PresentedViewController as UITabBarController;
                    if (navigationController != null)
                        tcs.SetResult(navigationController.TopViewController);
                    else if (tabBarController != null)
                        tcs.SetResult(tabBarController.SelectedViewController);
                    else if (rootController.PresentedViewController == null)
                        tcs.SetResult(rootController);
                    else
                        tcs.SetResult(rootController.PresentedViewController);
                } catch (Exception ex) {
                    tcs.SetException(ex);
                }

            });
            return tcs.Task;
        }
    }
}

