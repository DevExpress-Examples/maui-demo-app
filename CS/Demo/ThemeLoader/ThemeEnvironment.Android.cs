using System;
using System.Threading.Tasks;

namespace DemoCenter.Maui.Demo.ThemeLoader {
    internal partial class ThemeEnvironment {
        public MainActivity Activity { get; set; }

        public Task<bool> IsLightOperatingSystemTheme() {
            //Ensure the device is running Android Froyo or higher because UIMode was added in Android Froyo, API 8.0
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.Froyo) {
            //    UiMode uiModeFlags = Activity.ApplicationContext.Resources.Configuration.UiMode & UiMode.NightMask;
            //    switch (uiModeFlags) {
            //        case UiMode.NightYes:
            //            return Task.FromResult(false);
            //        case UiMode.NightNo:
            //            return Task.FromResult(true);
            //        default:
            //            return Task.FromResult(true);
            //    }
            //} else {
            //    return Task.FromResult(true);
            //}
            return Task.FromResult(true);
        }
    }
}

