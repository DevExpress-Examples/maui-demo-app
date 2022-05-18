using System;
using Foundation;
using Microsoft.Maui.Controls;
using UIKit;

namespace DemoCenter.Maui.Styles.ThemeLoader {
    internal partial class PlatformThemeLoader: NSObject, IThemeLoader {
        public void LoadTheme(ResourceDictionary theme, bool isLightTheme) {
            Device.BeginInvokeOnMainThread(() => {
                UIApplication.SharedApplication.SetStatusBarStyle(isLightTheme ? UIStatusBarStyle.Default : UIStatusBarStyle.LightContent, false);
                GetCurrentViewController().SetNeedsStatusBarAppearanceUpdate();
            });
        }
        UIViewController GetCurrentViewController() {
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            UIViewController viewController = window.RootViewController;
            while (viewController.PresentedViewController != null)
                viewController = viewController.PresentedViewController;
            return viewController;
        }
    }
}

