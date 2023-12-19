using System;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo {
    public class ScrollViewFix : ScrollView {
        protected override void OnChildAdded(Element child) {
            base.OnChildAdded(child);
            ((VisualElement)child).SizeChanged += OnContentSizeChanged;
        }

        protected override void OnChildRemoved(Element child, int oldLogicalIndex) {
            base.OnChildRemoved(child, oldLogicalIndex);
            ((VisualElement)child).SizeChanged -= OnContentSizeChanged;
        }

        void OnContentSizeChanged(object sender, EventArgs e) {
            InvalidateMeasure();
        }
    }
}

