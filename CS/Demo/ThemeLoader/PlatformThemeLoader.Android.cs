using System;
using System.Threading.Tasks;
using DemoCenter.Maui.Resources.Styles;
using DevExpress.Maui.Core.Themes;
using DevExpress.Utils;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Styles.ThemeLoader {
    internal partial class PlatformThemeLoader : Java.Lang.Object, IThemeLoader {
        public PlatformThemeLoader() {
        }
        public MainActivity Activity { get; set; }

        public void LoadTheme(ResourceDictionary theme, bool isLightTheme) {
            //Activity.UpdateNightMode(isLightTheme);
            Android.Graphics.Color backgroundColor = ((Color)theme["BackgroundThemeColor"]).ToAndroid();
            Device.BeginInvokeOnMainThread(() => {
                //Window currentWindow = GetCurrentWindow();
                //currentWindow.DecorView.SystemUiVisibility = isLightTheme ? (StatusBarVisibility)SystemUiFlags.LightStatusBar | (StatusBarVisibility)SystemUiFlags.LightNavigationBar : 0;
                //if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                //    currentWindow.SetStatusBarColor(backgroundColor);
                //}
                //if (Build.VERSION.SdkInt >= BuildVersionCodes.OMr1) {
                //    currentWindow.SetNavigationBarColor(backgroundColor);
                //}
            });

        }
        //Window GetCurrentWindow() {
        //    Window window = Activity.Window;
        //    window.ClearFlags(WindowManagerFlags.TranslucentStatus);
        //    window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
        //    return window;
        //}

    }
}

