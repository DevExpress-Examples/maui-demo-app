using Microsoft.Maui.Controls;
using DevExpress.Maui.Core;
using DemoCenter.Maui.Demo;
using Microsoft.Maui;

namespace DemoCenter.Maui.Views {
    public partial class SlideViewDemo : DemoPage {
        bool allowSwipe;
        public bool AllowSwipe {
            get => this.allowSwipe; set {
                if (this.allowSwipe == value)
                    return;
                this.allowSwipe = value;
                OnPropertyChanged();
            }
        }
        bool allowAnimation;
        public bool AllowAnimation {
            get => this.allowAnimation;
            set {
                if (this.allowAnimation == value)
                    return;
                this.allowAnimation = value;
                OnPropertyChanged();
            }
        }
        bool allowLooping;
        public bool AllowLooping {
            get => this.allowLooping;
            set {
                if (this.allowLooping == value)
                    return;
                this.allowLooping = value;
                OnPropertyChanged();
            }
        }
        int currentIndex;
        public int CurrentIndex {
            get => this.currentIndex;
            set {
                if (this.currentIndex == value)
                    return;
                this.currentIndex = value;
                OnPropertyChanged();
            }
        }
        StackOrientation orientation;
        public StackOrientation Orientation {
            get => this.orientation;
            set {
                if (this.orientation == value)
                    return;
                this.orientation = value;
                OnPropertyChanged();
                IsVertical = value == StackOrientation.Vertical;
                IsHorizontal = !IsVertical;
            }
        }
        bool isVertical;
        public bool IsVertical {
            get => this.isVertical;
            set {
                if (this.isVertical == value)
                    return;
                this.isVertical = value;
                OnPropertyChanged();
                IsHorizontal = !value;
                Orientation = value ? StackOrientation.Vertical : StackOrientation.Horizontal;
            }
        }
        bool isHorizontal;
        public bool IsHorizontal {
            get => this.isHorizontal;
            set {
                if (this.isHorizontal == value)
                    return;
                this.isHorizontal = value;
                OnPropertyChanged();
                IsVertical = !value;
                Orientation = value ? StackOrientation.Horizontal : StackOrientation.Vertical;
            }
        }

        public SlideViewDemo() {
            InitializeComponent();
            BindingContext = this;
            AllowSwipe = true;
            AllowAnimation = true;
            AllowLooping = true;
            Orientation = StackOrientation.Horizontal;
        }
    }

    public class SlideViewCard : DXBorder {
        public static readonly BindableProperty NumberProperty = BindableProperty.Create(nameof(Number), typeof(int),
            typeof(SlideViewCard), propertyChanged: NumberPropertyChanged);

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(bool),
            typeof(SlideViewCard), propertyChanged: ValuePropertyChanged);

        public static readonly BindableProperty Text1Property = BindableProperty.Create(nameof(Text1), typeof(string),
            typeof(SlideViewCard), propertyChanged: Text1PropertyChanged);

        public static readonly BindableProperty Text2Property = BindableProperty.Create(nameof(Text2), typeof(string),
            typeof(SlideViewCard), propertyChanged: Text2PropertyChanged);

        public static readonly BindableProperty Text3Property = BindableProperty.Create(nameof(Text3), typeof(string),
            typeof(SlideViewCard), propertyChanged: Text3PropertyChanged);

        public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int),
            typeof(SlideViewCard), propertyChanged: CountPropertyChanged);

        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource),
            typeof(SlideViewCard), propertyChanged: IconPropertyChanged);

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string),
            typeof(SlideViewCard), propertyChanged: TitlePropertyChanged);

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(nameof(Description), typeof(string),
            typeof(SlideViewCard), propertyChanged: DescriptionPropertyChanged);

        public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(nameof(IsActive), typeof(bool),
            typeof(SlideViewCard), defaultValue: true, propertyChanged: IsActivePropertyChanged);

        static void IconPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).Image.Source = (ImageSource)newValue;
        }
        static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).TitleLabel.Text = (string)newValue;
        }
        static void DescriptionPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).DescriptionLabel.Text = (string)newValue;
        }
        static void NumberPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).NumberSpan.Text = newValue.ToString();
        }
        static void CountPropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).CountSpan.Text = " / " + newValue.ToString();
        }
        static void IsActivePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).UpdateAppearance();
        }
        static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).UpdateAppearance();
        }
        static void Text1PropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).TextSpan1.Text = newValue.ToString();
        }
        static void Text2PropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).TextSpan2.Text = newValue.ToString();
        }
        static void Text3PropertyChanged(BindableObject bindable, object oldValue, object newValue) {
            ((SlideViewCard)bindable).TextSpan3.Text = newValue.ToString();
        }

        public int Number { get => (int)GetValue(NumberProperty); set => SetValue(NumberProperty, value); }
        public ImageSource Icon { get => (ImageSource)GetValue(IconProperty); set => SetValue(IconProperty, value); }
        public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
        public string Description { get => (string)GetValue(DescriptionProperty); set => SetValue(DescriptionProperty, value); }
        public int Count { get => (int)GetValue(CountProperty); set => SetValue(CountProperty, value); }
        public string Text1 { get => (string)GetValue(Text1Property); set => SetValue(Text1Property, value); }
        public string Text2 { get => (string)GetValue(Text1Property); set => SetValue(Text1Property, value); }
        public string Text3 { get => (string)GetValue(Text1Property); set => SetValue(Text1Property, value); }
        public bool IsActive { get => (bool)GetValue(IsActiveProperty); set => SetValue(IsActiveProperty, value); }
        public bool Value { get => (bool)GetValue(ValueProperty); set => SetValue(ValueProperty, value); }

        DXImage Image { get; }
        Label TitleLabel { get; }
        Label DescriptionLabel { get; }
        Label InfoLabel { get; }
        Span NumberSpan { get; }
        Span CountSpan { get; }
        Span TextSpan1 { get; }
        Span TextSpan2 { get; }
        Span TextSpan3 { get; }

        public SlideViewCard() {
            var stackLayout = new DXStackLayout();
            var dockLayout = new DXDockLayout();
            Image = new DXImage();
            var label = new Label();
            var fs = new FormattedString();
            var fs2 = new FormattedString();
            NumberSpan = new Span() { FontAttributes = FontAttributes.Bold, TextColor = ThemeManager.Theme.Scheme.OnSurface };
            CountSpan = new Span();
            TitleLabel = new Label();
            InfoLabel = new Label();
            DescriptionLabel = new Label();
            ON.OrientationChanged(this, (sender) => {
                Image.WidthRequest = ON.Portrait ? 48 : 40;
                Image.HeightRequest = ON.Portrait ? 48 : 40;
            }); 

            DXDockLayout.SetDock(Image, Dock.Left);
            DXDockLayout.SetDock(label, Dock.Right);
            label.HorizontalOptions = LayoutOptions.End;
            fs.Spans.Add(NumberSpan);
            fs.Spans.Add(CountSpan);
            label.FormattedText = fs;

            TitleLabel.Margin = new Thickness(0, 24, 0, 0);
            TitleLabel.FontAttributes = FontAttributes.Bold;
            TitleLabel.FontSize = 22;

            InfoLabel.Margin = new Thickness(0, 16, 0, 0);
            InfoLabel.FontSize = 22;
            TextSpan1 = new Span();
            TextSpan2 = new Span() { TextColor = ThemeManager.Theme.Scheme.OnSurface };
            TextSpan3 = new Span();
            fs2.Spans.Add(TextSpan1);
            fs2.Spans.Add(TextSpan2);
            fs2.Spans.Add(TextSpan3);
            InfoLabel.FormattedText = fs2;

            DescriptionLabel.FontSize = 16;
            DescriptionLabel.Margin = new Thickness(0, 24, 0, 0);

            dockLayout.Children.Add(Image);
            dockLayout.Children.Add(label);
            stackLayout.Children.Add(dockLayout);
            stackLayout.Children.Add(TitleLabel);
            stackLayout.Children.Add(InfoLabel);
            stackLayout.Children.Add(DescriptionLabel);
            Content = stackLayout;
            UpdateAppearance();
        }

        void UpdateAppearance() {
            BackgroundColor = IsActive ? ThemeManager.Theme.Scheme.PrimaryContainer : ThemeManager.Theme.Scheme.SurfaceContainer;
            Image.TintColor = IsActive ? ThemeManager.Theme.Scheme.Primary : ThemeManager.Theme.Scheme.OnSurfaceVariant;
            TitleLabel.TextColor = IsActive ? ThemeManager.Theme.Scheme.OnSurface : ThemeManager.Theme.Scheme.OnSurfaceVariant;
            DescriptionLabel.TextColor = IsActive ? ThemeManager.Theme.Scheme.OnSurface : ThemeManager.Theme.Scheme.OnSurfaceVariant;
            TextSpan1.TextColor = Value ? ThemeManager.Theme.Scheme.Tertiary : ThemeManager.Theme.Scheme.OnSurfaceVariant;
            TextSpan1.FontAttributes = Value ? FontAttributes.Bold : FontAttributes.None;
            TextSpan1.TextDecorations = Value ? TextDecorations.Underline : TextDecorations.None;
            TextSpan3.TextColor = !Value && IsActive ? ThemeManager.Theme.Scheme.Tertiary : ThemeManager.Theme.Scheme.OnSurfaceVariant;
            TextSpan3.FontAttributes = !Value ? FontAttributes.Bold : FontAttributes.None;
            TextSpan3.TextDecorations = !Value ? TextDecorations.Underline : TextDecorations.None;
        }
    }
}
