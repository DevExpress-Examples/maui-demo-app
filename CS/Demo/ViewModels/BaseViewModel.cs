using System.Windows.Input;
using DevExpress.Maui.Core.Themes;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.ViewModels {
    public class BaseViewModel : NotificationObject {
        bool isLightTheme = true;

        public string Title { get; set; }
        public bool IsLightTheme {
            get {
                isLightTheme = ThemeManager.ThemeName == Theme.Light;
                return isLightTheme;
            }
            set { SetProperty(ref isLightTheme, value, onChanged: () => ((App)Application.Current).ApplyTheme(isLightTheme, true)); }
        }

        public ICommand ThemeCommand { get; }

        public BaseViewModel() {
            ThemeCommand = new DelegateCommand(() => IsLightTheme = !isLightTheme);
        }
    }
}
