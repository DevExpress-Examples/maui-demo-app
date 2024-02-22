using System;
using System.Globalization;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    public class ColumnsCountToTemplateConverter : IValueConverter {
        public DataTemplate SmallCardTemplate { get; set; }
        public DataTemplate CardTemplate { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ON.Idiom<DataTemplate>((int)value > 1 ? SmallCardTemplate : CardTemplate, CardTemplate);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}