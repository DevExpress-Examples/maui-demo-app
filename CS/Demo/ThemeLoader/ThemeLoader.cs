using System;
using System.Threading.Tasks;
using DemoCenter.Maui.Resources.Styles;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Styles.ThemeLoader {
    public interface IEnvironment {
        Task<bool> IsLightOperatingSystemTheme();
    }

    internal class ThemeLoader {
        static ThemeLoader instance = null;
        IThemeLoader platformLoader = null;
        public static ThemeLoader Instance {
            get {
                if (instance == null)
                    instance = new ThemeLoader();

                return instance;
            }
        }
        public static bool IsLightTheme => Application.Current.RequestedTheme == AppTheme.Light;
        public static string ThemeName => IsLightTheme ? nameof(AppTheme.Light) : nameof(AppTheme.Dark);

        private ThemeLoader() {
            platformLoader = PlatformThemeLoader.Instance;
            Application.Current.RequestedThemeChanged += CurrentOnRequestedThemeChanged;
        }

        public void LoadTheme() {
            ResourceDictionary theme = null;
            if (IsLightTheme)
                theme = new LightTheme();
            else
                theme = new DarkTheme();

            if (theme != null) {
                Application.Current.Resources.MergedDictionaries.Add(theme);
                this.platformLoader?.LoadTheme(theme, IsLightTheme);
            }
        }
        void CurrentOnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e) => LoadTheme();
    }
    public interface IThemeLoader {
        void LoadTheme(ResourceDictionary theme, bool isLightTheme);
    }
}

