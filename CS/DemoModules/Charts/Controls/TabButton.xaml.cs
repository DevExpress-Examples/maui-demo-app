using DevExpress.Utils;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Demo {
    public partial class TabButton : ContentView {
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(string), typeof(TabButton));
        public string ImageSource { get => (string) GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(TabButton), Color.FromArgb("#CCCCCC"));
        public Color BorderColor { get => (Color) GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }

        public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create("SelectedColor", typeof(Color), typeof(TabButton), Color.FromArgb("#FFFFFF"));
        public Color SelectedColor { get => (Color) GetValue(SelectedColorProperty); set => SetValue(SelectedColorProperty, value); }
        public static readonly BindableProperty ActualBackgroundColorProperty = BindableProperty.Create("ActualBackgroundColor", typeof(Color), typeof(TabButton), DXColor.Transparent);
        public Color ActualBackgroundColor { get => (Color)GetValue(ActualBackgroundColorProperty); set => SetValue(ActualBackgroundColorProperty, value); }

        public static readonly BindableProperty IsVerticalProperty = BindableProperty.Create("IsVertical", typeof(bool), typeof(TabButton), false, propertyChanged: OnIsVerticalPropertyChanged);
        static void OnIsVerticalPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((TabButton)bindable).Update();
        }

        public bool IsVertical { get => (bool) GetValue(IsVerticalProperty); set => SetValue(IsVerticalProperty, value); }

        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(TabButton), false, propertyChanged: OnIsSelectedPropertyChanged);
        static void OnIsSelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((TabButton)bindable).Update();
        }

        public bool IsSelected { get => (bool) GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }

        public TabButton() {
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
