using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using DemoCenter.Maui.Resources.Styles;
using DevExpress.Maui.Core.Internal;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Graphics;
using Window = Android.Views.Window;

namespace DemoCenter.Maui.Styles.ThemeLoader {
    internal partial class PlatformThemeLoader : Java.Lang.Object, IThemeLoader {
        public PlatformThemeLoader() {}
        public MainActivity Activity { get; set; }

        public void LoadTheme(ResourceDictionary theme, bool isLightTheme) {
            Android.Graphics.Color backgroundColor = ((Color)theme["BackgroundThemeColor"]).ToAndroid();
            Application.Current.Dispatcher.Dispatch(() => {
                Window currentWindow = GetCurrentWindow();
                if (Build.VERSION.SdkInt < BuildVersionCodes.R) {
#pragma warning disable CA1422
                    currentWindow.DecorView.SystemUiVisibility = isLightTheme ? (StatusBarVisibility)SystemUiFlags.LightStatusBar | (StatusBarVisibility)SystemUiFlags.LightNavigationBar : 0;
#pragma warning restore CA1422
                }
                if (Build.VERSION.SdkInt >= BuildVersionCodes.OMr1)
                    currentWindow.SetNavigationBarColor(backgroundColor);
                else
                    currentWindow.SetStatusBarColor(backgroundColor);
            });
        }

        Window GetCurrentWindow() {
            Window window = Activity.Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            return window;
        }
    }
}

