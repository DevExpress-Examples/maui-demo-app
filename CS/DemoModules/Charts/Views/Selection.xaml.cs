using System;
using System.Globalization;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class Selection : Demo.DemoPage {
        static void OnOrientationChanged(Selection view) {
            if (ON.Landscape) {
                view.panel.ColumnDefinitions = new ColumnDefinitionCollection {
                   new ColumnDefinition(),
                   new ColumnDefinition(),
                };
                view.panel.RowDefinitions = new RowDefinitionCollection();
                view.panel.SetRow(view.grid2, 0);
                view.panel.SetColumn(view.grid2, 1);
                view.pieChart.Legend = new Legend {
                    Orientation = LegendOrientation.TopToBottom,
                    VerticalPosition = LegendVerticalPosition.Center,
                    HorizontalPosition = LegendHorizontalPosition.RightOutside,
                };
            } else {
                view.panel.ColumnDefinitions = new ColumnDefinitionCollection();
                view.panel.RowDefinitions = new RowDefinitionCollection {
                    new RowDefinition(),
                    new RowDefinition()
                };
                view.panel.SetColumn(view.grid2, 0);
                view.panel.SetRow(view.grid2, 1);
                view.pieChart.Legend = new Legend {
                    Orientation = LegendOrientation.LeftToRight,
                    VerticalPosition = LegendVerticalPosition.BottomOutside,
                    HorizontalPosition = LegendHorizontalPosition.Center,
                };
            }
        }
        public Selection() {
            InitializeComponent();
            ON.OrientationChanged(this, OnOrientationChanged);
            OnOrientationChanged(this);
        }
    }

    public class SelectionConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null)
                return true;
            DataSourceKey key = (DataSourceKey)value;
            PieData pie = (PieData)key.DataObject;
            return pie.Label.Equals(parameter);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
    public class ChartTitleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture = null) {
            string prefix = String.Empty;
            if (value != null) {
                DataSourceKey key = (DataSourceKey)value;
                PieData pie = (PieData)key.DataObject;
                prefix = pie.Label;
            }
            return String.Format("{0} Sales by Year", prefix);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
