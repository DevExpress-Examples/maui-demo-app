using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    public class RotationHandleView : ContentView {
        public RotationHandleView() {
            SizeChanged += (s, e) => UpdateOrientation(Width, Height);
            UpdateOrientation(Width, Height);
        }

        public static readonly BindablePropertyKey IsLandscapePropertyKey = BindableProperty.CreateReadOnly("IsLandscape", typeof(bool), typeof(RotationHandleView), false);
        public static readonly BindableProperty IsLandscapeProperty = IsLandscapePropertyKey.BindableProperty;
        public bool IsLandscape { get => (bool) GetValue(IsLandscapeProperty); }

        void UpdateOrientation(double width, double height) {
            SetValue(IsLandscapePropertyKey, width > height);
        }
    }
}
