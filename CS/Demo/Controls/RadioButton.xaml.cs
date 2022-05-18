
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo {
    public partial class RadioButton : ContentView {
        public static readonly BindableProperty ThemeNameProperty = BindableProperty.Create(
            nameof(RadioButton.ThemeName), typeof(string), typeof(RadioButton),
            propertyChanged: ThemeNamePropertyChanged);

        static void ThemeNamePropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((RadioButton)bindable).OnThemeNameChanged((string)newValue);

        public string ThemeName {
            get => (string)GetValue(ThemeNameProperty);
            set => SetValue(ThemeNameProperty, value);
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(RadioButton.IsSelected), typeof(bool), typeof(RadioButton),
                propertyChanged: SelectedPropertyChanged, defaultBindingMode: BindingMode.TwoWay);

        static void SelectedPropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((RadioButton)bindable).OnSelectedChanged((bool)newValue);

        public bool IsSelected {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(RadioButton.LabelText), typeof(string), typeof(RadioButton));

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public static readonly BindableProperty BackgroundImageProperty =
            BindableProperty.Create(nameof(RadioButton.BackgroundImage), typeof(ImageSource), typeof(RadioButton));

        public ImageSource BackgroundImage {
            get => (ImageSource)GetValue(BackgroundImageProperty);
            private set => SetValue(BackgroundImageProperty, value);
        }

        public RadioButton() {
            OnSelectedChanged(this.IsSelected);
            this.BindingContext = this;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                if (!this.IsSelected)
                    this.IsSelected = true;
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
            InitializeComponent();                 
        }

        private void OnThemeNameChanged(string newValue) {
        }

        private void OnSelectedChanged(bool newValue) {
            string resourceName = IsSelected ? "radiobuttonchecked" : "radiobutton";
            this.BackgroundImage = resourceName;
        }
    }
}
