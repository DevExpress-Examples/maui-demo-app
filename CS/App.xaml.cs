using System;
using System.Globalization;
using System.Threading;
using DemoCenter.Maui.Demo.ThemeLoader;
using DemoCenter.Maui.Styles.ThemeLoader;
using DevExpress.Maui.Core.Themes;
using Microsoft.Maui.Graphics;
using Application = Microsoft.Maui.Controls.Application;

namespace DemoCenter.Maui {
    public partial class App : Application {
        bool themeIsSetting = false;
        internal event EventHandler ThemeChangedEvent;

        readonly ThemeEnvironment themeEnvironment;
        public App() {
			InitializeComponent();

            PlatformLocale locale = new PlatformLocale();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale.GetPlatformLocale());

            AppShell rootPage = new AppShell();
            MainPage = rootPage;

            this.themeEnvironment = new ThemeEnvironment();
            //ThemeManager.ThemeName = Theme.Dark;
            ThemeLoader.Instance.LoadTheme();
        }
        protected override async void OnStart() {
            base.OnStart();
            bool lightTheme = await this.themeEnvironment.IsLightOperatingSystemTheme();
            ApplyTheme(lightTheme);
        }
        protected override void OnResume() {
            base.OnResume();
            //if (!this.themeIsSetting) {
            //    bool lightTheme = ThemeManager.ThemeName == Theme.Dark;
            //    ApplyTheme(lightTheme);
            //}
        }
        void ApplyTheme(bool isLightTheme) {
            ThemeManager.ThemeName = isLightTheme ? Theme.Light : Theme.Dark;
            MainPage.BackgroundColor = (Color)Resources["BackgroundThemeColor"];
            ThemeChangedEvent?.Invoke(this, EventArgs.Empty);
        }
        internal void ApplyTheme(bool isLightTheme, bool force) {
            if (force) {
                ApplyTheme(isLightTheme);
                this.themeIsSetting = true;
            }
        }
    }
}
