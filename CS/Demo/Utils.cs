using System;
using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui {
    public class InverseBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool) value;
    }

    public class BoolToObjectConverter : IValueConverter {
        public object FalseValue { get; set; }
        public object TrueValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var result = (bool)value ? TrueValue : FalseValue;
            var typeConverter = TypeDescriptor.GetConverter(targetType);
            return typeConverter.ConvertFrom(null, CultureInfo.InvariantCulture, result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class BoolToStackOrientationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(StackOrientation)) {
                if (parameter is string && ((string) parameter) == "inverse")
                    return (bool) value ? StackOrientation.Horizontal : StackOrientation.Vertical;
                else
                    return (bool) value ? StackOrientation.Vertical : StackOrientation.Horizontal;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToScrollOrientationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(ScrollOrientation)) {
                if (parameter is string && ((string) parameter) == "inverse")
                    return (bool) value ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical;
                else
                    return (bool) value ? ScrollOrientation.Vertical : ScrollOrientation.Horizontal;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToHeaderPanelPositionConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(DevExpress.Maui.Controls.Position)) {
                return (bool) value ? DevExpress.Maui.Controls.Position.Left : DevExpress.Maui.Controls.Position.Top;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToFileImageSourceConverter : IValueConverter {
        public FileImageSource FalseSource { get; set; }
        public FileImageSource TrueSource { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is bool)) {
                return null;
            }
            return (bool)value ? TrueSource : FalseSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class BoolToColorConverter : IValueConverter {
        public Color FalseSource { get; set; }
        public Color TrueSource { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (!(value is bool)) {
                return null;
            }
            return (bool)value ? TrueSource : FalseSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class TitleViewExtensions {
        public static BindableProperty IsShadowVisibleProperty =
            BindableProperty.CreateAttached("IsShadowVisible", typeof(bool), typeof(Page), false);

        public static bool GetIsShadowVisible(Page view) {
            return (bool) view.GetValue(IsShadowVisibleProperty);
        }

        public static void SetIsShadowVisible(Page view, bool value) {
            view.SetValue(IsShadowVisibleProperty, value);
        }
    }

}

namespace DemoCenter.PlatformConfiguration.iOSSpecific {
    using FormsElement = NavigationPage;
    public static class Page {
        public static readonly BindableProperty DisablePopInteractiveProperty = BindableProperty.Create(nameof(DisablePopInteractive), typeof(bool), typeof(Page), false);

        public static bool GetDisablePopInteractive(BindableObject element)
        {
            return (bool)element.GetValue(DisablePopInteractiveProperty);
        }

        public static void SetDisablePopInteractive(BindableObject element, bool value)
        {
            element.SetValue(DisablePopInteractiveProperty, value);
        }

        public static IPlatformElementConfiguration<iOS, FormsElement> SetDisablePopInteractive(this IPlatformElementConfiguration<iOS, FormsElement> config, bool value)
        {
            SetDisablePopInteractive(config.Element, value);
            return config;
        }

        public static bool DisablePopInteractive(this IPlatformElementConfiguration<iOS, FormsElement> config)
        {
            return GetDisablePopInteractive(config.Element);
        }
    }

}
