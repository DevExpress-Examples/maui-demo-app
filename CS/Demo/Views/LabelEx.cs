using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public class LabelEx : Label {
        public const int label_size = 100;
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint) {
            return new SizeRequest() { Request = new Size(label_size, label_size), Minimum = new Size(0, 0) };
        }
    }
}
