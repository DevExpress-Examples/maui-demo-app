using System;
using System.Globalization;
using System.Threading;
using DemoCenter.Maui.Demo.ThemeLoader;
using DemoCenter.Maui.Styles.ThemeLoader;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Graphics;
using Application = Microsoft.Maui.Controls.Application;

namespace DemoCenter.Maui {
    public partial class App : Application {
        internal event EventHandler ThemeChangedEvent;

        public App() {
			InitializeComponent();

            PlatformLocale locale = new PlatformLocale();
            Thread.CurrentThread.CurrentCulture = new CultureInfo(locale.GetPlatformLocale());

            AppShell rootPage = new AppShell();
            MainPage = rootPage;
            ThemeLoader.Instance.LoadTheme();
        }
        protected override async void OnStart() {
            base.OnStart();
            bool lightTheme = await ThemeEnvironment.Instance.IsLightOperatingSystemTheme();
            ApplyTheme(lightTheme);
        }
        internal void ApplyTheme(bool isLightTheme) {
            Application.Current.UserAppTheme = isLightTheme ? AppTheme.Light : AppTheme.Dark;
            MainPage.BackgroundColor = (Color)Resources["BackgroundThemeColor"];
            ThemeChangedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
