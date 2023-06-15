using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace DemoCenter.Maui {
    public static class BioHelper {
        public const string bioText = "Bio";
        public const string detailText = "Add a few words about yourself";
    }
    public class BioTextConverter : IMarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return String.IsNullOrEmpty(value?.ToString()) ? BioHelper.bioText : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public object ProvideValue(IServiceProvider serviceProvider) => this;
    }

    public class BioDetailsConverter : IMarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return String.IsNullOrEmpty(value?.ToString()) ? BioHelper.detailText : BioHelper.bioText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();

        public object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
