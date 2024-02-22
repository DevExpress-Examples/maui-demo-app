using System;
using System.Globalization;
using DemoCenter.Maui.Demo;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;
using static DemoCenter.Maui.ViewModels.RadialProgressBarViewModel;

namespace DemoCenter.Maui.Views;

public partial class RadialProgressBarView : DemoPage {
    public RadialProgressBarView() {
        InitializeComponent();
        ON.OrientationChanged(this, UpdateLayoutOptions);
        UpdateLayoutOptions(this);
    }

    static void UpdateLayoutOptions(RadialProgressBarView x) {
        if (ON.Landscape && !ON.Tablet) {
            x.grid2.IsVisible = true;
            x.grid1.IsVisible = false;
        } else {
            x.grid2.IsVisible = false;
            x.grid1.IsVisible = true;
        }
    }
}

public class StatusToBoolConverter : IValueConverter {
    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is not TestStatus || targetType != typeof(bool)) {
            return null;
        }

        return value switch {
            TestStatus.Starting or TestStatus.Finishing or TestStatus.Finished => true,
            _ => false
        };
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}
