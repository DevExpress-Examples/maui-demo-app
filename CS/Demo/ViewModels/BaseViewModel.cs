using System.Windows.Input;
using DemoCenter.Maui.Styles.ThemeLoader;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.ViewModels {
    public class BaseViewModel : NotificationObject {
        bool isLightTheme = true;

        public string Title { get; set; }
        public bool IsLightTheme {
            get {
                isLightTheme = ThemeLoader.IsLightTheme;
                return isLightTheme;
            }
            set { SetProperty(ref isLightTheme, value, onChanged: () => ((App)Application.Current).ApplyTheme(isLightTheme)); }
        }

        public ICommand ThemeCommand { get; }

        public BaseViewModel() {
            ThemeCommand = new Command(() => IsLightTheme = !isLightTheme);
        }
    }
}
