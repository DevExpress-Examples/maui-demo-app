using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Graphics;
using Rectangle = Microsoft.Maui.Graphics.Rect;

namespace DemoCenter.Maui.Demo {
    public class Panel : Layout<View> {
        public static readonly BindablePropertyKey IsLandscapePropertyKey = BindableProperty.CreateReadOnly("IsLandscape", typeof(bool), typeof(Panel), false);
        public static readonly BindableProperty IsLandscapeProperty = IsLandscapePropertyKey.BindableProperty;
        public bool IsLandscape => (bool)GetValue(IsLandscapeProperty);

        public Panel() {
            SizeChanged += (s, e) => UpdateOrientation(Width, Height);
            UpdateOrientation(Width, Height);
        }

        void UpdateOrientation(double width, double height) {
            SetValue(IsLandscapePropertyKey, width > height);
        }

        protected override void LayoutChildren(double x, double y, double width, double height) {
            UpdateOrientation(Width, Height);
            int visibleChildCount = 0;
            foreach (View child in Children)
                visibleChildCount += child.IsVisible ? 1 : 0;
            if (visibleChildCount > 0) {
                double itemSize = (IsLandscape ? width : height) / visibleChildCount;
                double offset = 0;
                foreach(View child in Children)
                    if (child.IsVisible) {
                        if (IsLandscape)
                            LayoutChildIntoBoundingRegion(child, new Rect(x + offset, y, itemSize, height));
                        else
                            LayoutChildIntoBoundingRegion(child, new Rect(x, y + offset, width, itemSize));
                        offset += itemSize;
                    }
            }
        }
    }
}
