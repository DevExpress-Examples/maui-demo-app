using CoreGraphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;
using System;

namespace DemoCenter.Maui;

public class CustomTitleViewContainer : ShellPageRendererTracker.TitleViewContainer {
    public CustomTitleViewContainer(View view) : base(view) {
        HeightProperty = new HiddenPropertyInfo<Double?>(this, "Height");
    }
    HiddenPropertyInfo<Double?> HeightProperty { get; }

    public override void LayoutSubviews() {
        if (HeightProperty.Value == null || HeightProperty.Value == 0) {
            UpdateFrame(Superview);
        }
        base.LayoutSubviews();
    }
    void UpdateFrame(UIView newSuper) {
        if (newSuper is not null) {
            if (!(OperatingSystem.IsIOSVersionAtLeast(11) || OperatingSystem.IsTvOSVersionAtLeast(11)))
                Frame = new CGRect(Frame.X, newSuper.Bounds.Y, Frame.Width, newSuper.Bounds.Height);
            HeightProperty.Value = newSuper.Bounds.Height;
        }
    }
}