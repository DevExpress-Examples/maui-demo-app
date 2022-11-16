using Android.App;
using Android.Content.PM;
using Microsoft.Maui;
using Java.Util.Logging;
using DemoCenter.Maui.Styles.ThemeLoader;
using Android.OS;
using DemoCenter.Maui.Demo.ThemeLoader;

namespace DemoCenter.Maui
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            PlatformThemeLoader.Instance.Activity = this;
            ThemeEnvironment.Instance.Activity = this;
        }
    }
}