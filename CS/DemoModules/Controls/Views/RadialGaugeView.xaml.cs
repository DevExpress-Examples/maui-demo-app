using System;
using System.Globalization;
using DemoCenter.Maui.Demo;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using DevExpress.Maui.Gauges;
using SkiaSharp.Views.Maui;
using Microsoft.Maui.Devices;
using DevExpress.Maui.Core;

namespace DemoCenter.Maui.Views;

public partial class RadialGaugeView : DemoPage {
    public RadialGaugeView() {
        InitializeComponent();
    }

    protected override void OnAppearing() {
        base.OnAppearing();
        RadialGaugeViewModel viewModel = (RadialGaugeViewModel)BindingContext;
        viewModel.StartObserving();
    }

    protected override void OnDisappearing() {
        RadialGaugeViewModel viewModel = (RadialGaugeViewModel)BindingContext;
        viewModel.StopObserving();
        base.OnDisappearing();
    }

    void OnCustomizeTickmark(object sender, CustomizeTickmarkEventArgs e) {
        RadialScale scale = (RadialScale)sender;
        if (e.Value != scale.StartValue && e.Value != scale.EndValue) {
            Color tickMarkColor = e.IsMajor ? ThemeManager.Theme.Scheme.OnSurfaceVariant : ThemeManager.Theme.Scheme.OutlineVariant;
            e.Paint = new SkiaSharp.SKPaint() {
                Color = tickMarkColor.ToSKColor(),
                IsAntialias = true,
                IsStroke = true,
                StrokeWidth = (float)((e.IsMajor ? scale.MajorTickmarkThickness : scale.MinorTickmarkThickness) * DeviceDisplay.MainDisplayInfo.Density),
                StrokeCap = SkiaSharp.SKStrokeCap.Round,
            };
            e.Offset = e.IsMajor ? scale.MajorTickmarkOffset : scale.MinorTickmarkOffset;
            e.Length = e.IsMajor ? scale.MajorTickmarkLength : scale.MinorTickmarkLength;
            return;
        }

        Color color = e.Value == scale.StartValue ? Color.FromArgb("#9BBB72") : Color.FromArgb("#EF938D");

        e.Paint = new SkiaSharp.SKPaint() {
            Color = color.ToSKColor(),
            IsAntialias = true,
            IsStroke = true,
            StrokeWidth = (float)(scale.MajorTickmarkThickness * DeviceDisplay.MainDisplayInfo.Density),
            StrokeCap = SkiaSharp.SKStrokeCap.Round,
        };
        e.Length = ON.Idiom(14d, 20d);
        e.Offset = -scale.Thickness / 2d - e.Length / 2d;
    }
}

public class ValueToColorConverter : IValueConverter {


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (value is not double chargeLevel) {
            throw new NotImplementedException();
        }

        double hue = chargeLevel * 120d / 360d;
        double saturation = 0.79d - 0.45d * chargeLevel * chargeLevel;
        double luminosity = 0.59d;

        return Color.FromHsla(hue, saturation, luminosity);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException();
    }
}