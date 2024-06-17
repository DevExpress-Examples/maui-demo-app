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

    public class BoolToObjectConverter : IValueConverter, IMarkupExtension {
        public object FalseValue { get; set; }
        public object TrueValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => this;
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

    public class BoolToImageSourceConverter : IValueConverter {
        public ImageSource FalseSource { get; set; }
        public ImageSource TrueSource { get; set; }

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

    public class EnumToBooleanConverter : IValueConverter, IMarkupExtension {
        [Flags]
        public enum BackConversionMode {
            ConvertTrueValue = 1 << 0,
            ConvertFalseValue = 1 << 1,
            All = ConvertTrueValue | ConvertFalseValue
        }

        public string TrueValue { get; set; }
        public string FalseValue { get; set; }
        public BackConversionMode ConvertBackMode { get; set; } = BackConversionMode.All;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (TrueValue != null)
                return value?.ToString() == TrueValue;
            if (FalseValue != null)
                return value?.ToString() != FalseValue;
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (TrueValue != null && object.Equals(value, true) && ConvertBackMode.HasFlag(BackConversionMode.ConvertTrueValue)) {
                return Enum.Parse(targetType, TrueValue);
            }
            if (FalseValue != null && object.Equals(value, false) && ConvertBackMode.HasFlag(BackConversionMode.ConvertFalseValue)) {
                return Enum.Parse(targetType, FalseValue);
            }
            return Binding.DoNothing;
        }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => this;
    }
}