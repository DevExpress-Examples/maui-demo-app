using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views;

public class TitleViewFix : Grid {
    bool isMeasured;
    public TitleViewFix() {
    }
    protected override Size MeasureOverride(double widthConstraint, double heightConstraint) {
        this.isMeasured = true;
        return base.MeasureOverride(widthConstraint, heightConstraint);
    }
    protected override Size ArrangeOverride(Rect bounds) {
        if (!this.isMeasured)
            Measure(bounds.Width, double.PositiveInfinity, MeasureFlags.None);
        if (bounds.Height == 0)
            bounds.Height = DesiredSize.Height + 12;
        return base.ArrangeOverride(bounds);
    }
}