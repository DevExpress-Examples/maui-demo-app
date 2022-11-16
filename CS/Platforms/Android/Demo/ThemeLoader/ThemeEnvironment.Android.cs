using System;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.OS;

namespace DemoCenter.Maui.Demo.ThemeLoader {
    internal partial class ThemeEnvironment {
        public MainActivity Activity { get; set; }

        public Task<bool> IsLightOperatingSystemTheme() {
            UiMode uiModeFlags = Activity.ApplicationContext.Resources.Configuration.UiMode & UiMode.NightMask;
            switch (uiModeFlags) {
                case UiMode.NightYes:
                    return Task.FromResult(false);
                case UiMode.NightNo:
                    return Task.FromResult(true);
                default:
                    return Task.FromResult(true);
            }
        }
    }
}

