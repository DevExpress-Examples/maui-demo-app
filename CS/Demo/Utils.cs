using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using DevExpress.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui {
    public class InverseBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
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
                if (parameter is string && ((string)parameter) == "inverse")
                    return (bool)value ? StackOrientation.Horizontal : StackOrientation.Vertical;
                else
                    return (bool)value ? StackOrientation.Vertical : StackOrientation.Horizontal;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToScrollOrientationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(ScrollOrientation)) {
                if (parameter is string && ((string)parameter) == "inverse")
                    return (bool)value ? ScrollOrientation.Horizontal : ScrollOrientation.Vertical;
                else
                    return (bool)value ? ScrollOrientation.Vertical : ScrollOrientation.Horizontal;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }

    public class BoolToHeaderPanelPositionConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool && targetType == typeof(HeaderContentPosition)) {
                return (bool)value ? HeaderContentPosition.Left : HeaderContentPosition.Top;
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
    public class EnumToDescriptionConverter : IMarkupExtension, IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return Convert(value);
        }

        public object Convert(object value) {
            var enumValue = (Enum)value;
            var member = enumValue.GetType().GetMember(enumValue.ToString());
            var attributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? ((DescriptionAttribute)attributes[0]).Description : null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }

        public object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
    public class EnumToItemsSource : IMarkupExtension {
        public Type EnumType { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider) {
            return Enum.GetValues(EnumType);
        }
    }
    public class HiddenPropertyInfo<T> {
        PropertyInfo propertyInfo;

        public HiddenPropertyInfo(Object obj, string propertyName) {
            Type = obj.GetType();
            PropertyName = propertyName;
            Instance = obj;
        }

        public T Value {
            get { return (T)PropertyInfo.GetValue(Instance); }
            set { PropertyInfo.SetValue(Instance, value); }
        }
        Type Type { get; }
        string PropertyName { get; }
        object Instance { get; }
        PropertyInfo PropertyInfo {
            get {
                if (this.propertyInfo == null) {
                    Type currentType = Type;
                    while (currentType != null) {
                        this.propertyInfo = currentType.GetProperty(PropertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                        if (this.propertyInfo != null) {
                            break;
                        }
                        currentType = currentType.BaseType;
                    }
                }
                return this.propertyInfo;
            }
        }
    }
}