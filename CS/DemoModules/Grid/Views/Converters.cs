using System;
using System.Globalization;
using DevExpress.Maui.Core.Themes;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public class DeltaToColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            double delta = (double)value;
            if (delta > 0)
                return Color.FromRgb(48, 172, 28);

            if (delta < 0)
                return Color.FromRgb(241, 85, 88);

            return Color.FromRgb(231, 171, 24);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class DeltaToImageConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            double delta = (double)value;
            if (delta > 0)
                return "trianglepositive";

            if (delta < 0)
                return "trianglenegative";

            return "triangleundefined";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class DepartmentToImageConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            GroupRowData rowData = value as GroupRowData;
            if (rowData == null)
                return "";

            return ThemeManager.ThemeName.ToLowerInvariant() + "demogrid" + rowData.Value.ToString().Replace(" ", "").ToLowerInvariant();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
