using System;
using System.Globalization;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.DemoModules.Editors.ViewModels;
using DevExpress.Maui.Core;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class ApplicationDeploymentForm : AdaptivePage {
        ApplicationDeploymentViewModel viewModel;

        public ApplicationDeploymentForm() {
            viewModel = new ApplicationDeploymentViewModel();
            if (ThemeManager.IsLightTheme) {
                viewModel.Model.AppIcon = ImageSource.FromFile("appdeployment_light");
            } else {
                viewModel.Model.AppIcon = ImageSource.FromFile("appdeployment_dark");
            }
            this.BindingContext = viewModel;
            InitializeComponent();
            if (DeviceInfo.Idiom != DeviceIdiom.Tablet)
                OrientationChanged += OnOrientationChanged;
        }

        protected override void OnAppearing() {
            base.OnAppearing();
#if IOS
            Microsoft.Maui.Platform.KeyboardAutoManagerScroll.Disconnect();
#endif
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
#if IOS
            Microsoft.Maui.Platform.KeyboardAutoManagerScroll.Connect();
#endif
        }

        void OnOrientationChanged(object sender, EventArgs e) {
            bool isVertical = Orientation == PageOrientation.Portrait;

            if (isVertical) {
                this.photoContainer.Margin = new Thickness(0);
            } else {
                this.photoContainer.Margin = new Thickness(0, 50);
            }

            this.viewModel.Rotate(dataForm, Orientation);
        }

        void SubmitOnClicked(object sender, EventArgs e) {
            if (dataForm.Validate()) {
                dataForm.Commit();
                DisplayAlert("Success", "Your account has been created successfully", "OK");
            }
        }
    }

    public class LanguageNameConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            string englishName = (string)values[0];
            string nativeName = (string)values[1];
            if (string.IsNullOrEmpty(englishName) || string.IsNullOrEmpty(englishName))
                return string.Empty;
            else
                return $"{englishName} | {nativeName}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
