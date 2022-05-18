using System;
using System.Globalization;
using System.Threading.Tasks;
using DemoCenter.Maui.DemoModules.TabView.Pages;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Controls;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public class UpperCaseConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            return value?.ToString().ToUpperInvariant();
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return value?.ToString().ToLowerInvariant();
        }
    }

    public class CallTypeToIconConverter : IValueConverter {
        public object Convert(object value, Type targetType,
                             object parameter, CultureInfo culture) {
            return String.Format("demotabview{0}", value.ToString().ToLowerInvariant());
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            return null;
        }
    }

    public class ContactIconTemplateSelector : DataTemplateSelector {
        public DataTemplate PhotoTemplate { get; set; }
        public DataTemplate IconTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            if (item is CellData gridData)
                return OnSelectTemplate(gridData.Item, container);
            if (item is PhoneContact contact)
                return contact.HasPhoto ? PhotoTemplate : IconTemplate;
            if (item is CallInfo callInfo)
                return OnSelectTemplate(callInfo.Contact, container);
            return IconTemplate;
        }
    }
}
