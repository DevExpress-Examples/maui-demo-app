using System;
using System.Threading.Tasks;
using DemoCenter.Maui.Resources.Styles;
using DevExpress.Maui.Core.Themes;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Styles.ThemeLoader {
    public interface IEnvironment {
        Task<bool> IsLightOperatingSystemTheme();
    }

    internal class ThemeLoader : IThemeChangingHandler {
        static ThemeLoader instance = null;
        IThemeLoader platformLoader = null;
        public static ThemeLoader Instance {
            get {
                if (instance == null)
                    instance = new ThemeLoader();

                return instance;
            }
        }

        private ThemeLoader() {
            platformLoader = PlatformThemeLoader.Instance;
            ThemeManager.AddThemeChangedHandler(this);
        }

        public void LoadTheme() {
            bool isLightTheme = ThemeManager.ThemeName == Theme.Light;
            ResourceDictionary theme = null;
            if (isLightTheme) {
                theme = new LightTheme();
            } else {
                theme = new DarkTheme();
            }
            if (theme != null) {
                Application.Current.Resources.MergedDictionaries.Add(theme);
                this.platformLoader?.LoadTheme(theme, isLightTheme);
            }
        }

        void IThemeChangingHandler.OnThemeChanged() {
            LoadTheme();
        }
    }
    public interface IThemeLoader {
        void LoadTheme(ResourceDictionary theme, bool isLightTheme);
    }
}

