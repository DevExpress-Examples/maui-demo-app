using DevExpress.Maui.Core.Internal;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Demo {
    public partial class ChartsDemoTabButton : ContentView {
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ChartsDemoTabButton));
        public string ImageSource { get => (string)GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ChartsDemoTabButton), Color.FromArgb("#CCCCCC"));
        public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(ChartsDemoTabButton), Color.FromArgb("#FFFFFF"));
        public Color SelectedColor { get => (Color)GetValue(SelectedColorProperty); set => SetValue(SelectedColorProperty, value); }
        public static readonly BindableProperty ActualBackgroundColorProperty = BindableProperty.Create(nameof(ActualBackgroundColor), typeof(Color), typeof(ChartsDemoTabButton), DXColor.Transparent);
        public Color ActualBackgroundColor { get => (Color)GetValue(ActualBackgroundColorProperty); set => SetValue(ActualBackgroundColorProperty, value); }

        public static readonly BindableProperty IsVerticalProperty = BindableProperty.Create(nameof(IsVertical), typeof(bool), typeof(ChartsDemoTabButton), false, propertyChanged: OnIsVerticalPropertyChanged);
        static void OnIsVerticalPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((ChartsDemoTabButton)bindable).Update();
        }

        public bool IsVertical { get => (bool)GetValue(IsVerticalProperty); set => SetValue(IsVerticalProperty, value); }

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(ChartsDemoTabButton), false, propertyChanged: OnIsSelectedPropertyChanged);
        static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((ChartsDemoTabButton)bindable).Update();
        }

        public bool IsSelected { get => (bool)GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }

        public ChartsDemoTabButton() {
            InitializeComponent();
            this.icon.BindingContext = this;
        }
        void Update() {
            ActualBackgroundColor = IsSelected ? SelectedColor : BackgroundColor;
            this.horizontalBorder.IsVisible = !IsVertical;
            this.verticalBorder.IsVisible = IsVertical;
        }
    }
}
