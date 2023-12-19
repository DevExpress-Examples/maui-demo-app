using System;
using DevExpress.Maui.Core;
using DevExpress.Maui.Core.Internal;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Demo {
    public partial class IconView : Image {
        public static readonly BindableProperty ThemeNameProperty = BindableProperty.Create(nameof(ThemeName), typeof(string),
            typeof(IconView), propertyChanged: ThemeNamePropertyChanged, defaultValue: nameof(AppTheme.Light));

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string),
            typeof(IconView), propertyChanged: IconPropertyChanged, defaultValue: null);

        static void ThemeNamePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            IconView iconView = (IconView)bindable;
            iconView.OnThemeNameChanged((string)newValue);
            if (!String.IsNullOrEmpty(iconView.Icon))
                iconView.SetValue(SourceProperty, GetImageSource(((IconView)bindable).Icon));
        }

        static void IconPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((IconView)bindable).SetValue(SourceProperty, GetImageSource(newValue as string));
        }

        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(nameof(ForegroundColor),
            typeof(Color), typeof(IconView), defaultValue: DXColor.Default,
            propertyChanged: ForegroundColorPropertyChanged);

        static void ForegroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) { }

        public IconView() {
            InitializeComponent();
            if (App.Current is DemoCenter.Maui.App demoCenterApp) {
                ThemeManager.ThemeChangedWeakEvent += OnDemoCenterAppThemeChanged;
            }
        }

        void OnDemoCenterAppThemeChanged(object sender, EventArgs e) {
            ThemeName = GetThemeName();
            if (Source is FileImageSource)
                OnPropertyChanged(nameof(Image.Source));
        }

        public string ThemeName {
            get => (string)GetValue(ThemeNameProperty);
            set => SetValue(ThemeNameProperty, value);
        }
        public string Icon {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public Color ForegroundColor {
            get => (Color)GetValue(ForegroundColorProperty);
            set => SetValue(ForegroundColorProperty, value);
        }
        void OnThemeNameChanged(string newValue) {
        }
        static string GetImageSource(string icon) {
            return GetThemeName() + icon;
        }
        static string GetThemeName() {
            string themeName = ThemeManager.IsLightTheme ? nameof(AppTheme.Light) : nameof(AppTheme.Dark);
            return themeName.ToLower();
        }
    }
}
