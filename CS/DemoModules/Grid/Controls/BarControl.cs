using System;
using DevExpress.Utils;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public class BarControl : ContentView {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(double), typeof(BarControl), 0d, propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create("MaxValue", typeof(double), typeof(BarControl), 0d, propertyChanged: OnLayoutChanged);
        public static readonly BindableProperty ColorProperty = BindableProperty.Create("Color", typeof(Color), typeof(BarControl), DXColor.Cyan, propertyChanged: OnColorChanged);// TO DO LightCyan

        static void OnLayoutChanged(BindableObject bindable, object oldValue, object newValue) {
            ((BarControl)bindable).InvalidateLayout();
        }

        static void OnColorChanged(BindableObject bindable, object oldValue, object newValue) {
            ((BarControl)bindable).UpdateColor();
        }

        public BarControl() {
            Content = new BoxView() { BackgroundColor = Color };
        }

        public double Value {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double MaxValue {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public Color Color {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        void UpdateColor() {
            ((BoxView)Content).BackgroundColor = Color;
        }

        protected override Size ArrangeOverride(Rect bounds) {
            double actualWidth = Math.Min(Value / MaxValue * bounds.Width + Padding.HorizontalThickness + Margin.HorizontalThickness, bounds.Width);
            return base.ArrangeOverride(new Rect(bounds.X, bounds.Y, actualWidth, bounds.Height));
        }
    }
}