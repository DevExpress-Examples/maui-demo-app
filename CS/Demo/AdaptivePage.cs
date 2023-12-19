using System;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo {
    public abstract class AdaptivePage : DemoPage {
        public static readonly BindablePropertyKey OrientationPropertyKey = BindableProperty.CreateReadOnly(nameof(Orientation), typeof(PageOrientation), typeof(AdaptivePage), PageOrientation.Unknown);
        public static readonly BindableProperty OrientationProperty = OrientationPropertyKey.BindableProperty;
        public PageOrientation Orientation => (PageOrientation)GetValue(OrientationProperty);

        public EventHandler OrientationChanged;

        private bool isOldSizeStored;
        private Size oldPageSize = Size.Zero;

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            var currentSize = new Size(width, height);
            if (!isOldSizeStored) {
                oldPageSize = currentSize;
                isOldSizeStored = true;
                SetValue(OrientationPropertyKey, width > height ? PageOrientation.Landscape : PageOrientation.Portrait);
                this.OrientationChanged?.Invoke(this, EventArgs.Empty);
            }

            if (KeyboardAction(oldPageSize, currentSize))
                return;

            if (oldPageSize != currentSize) {
                oldPageSize = currentSize;
                ChangeOrientation();
            }
        }

        void ChangeOrientation() {
#if IOS
            if (Orientation == PageOrientation.Landscape && oldPageSize.Width > oldPageSize.Height)
                return;
            if (Orientation == PageOrientation.Portrait && oldPageSize.Width < oldPageSize.Height)
                return;
#endif
            if (Orientation == PageOrientation.Landscape) {
                SetValue(OrientationPropertyKey, PageOrientation.Portrait);
            } else {
                SetValue(OrientationPropertyKey, PageOrientation.Landscape);
            }
            this.OrientationChanged?.Invoke(this, EventArgs.Empty);
        }

        bool KeyboardAction(Size old, Size current) {
            return (old.Width == current.Width || old.Height == current.Height);
        }
    }

    public enum PageOrientation {
        Landscape, Portrait, Unknown
    }
}

