using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Layouts;

namespace DemoCenter.Maui.Demo {
    public enum Dock { Left, Top, Right, Bottom }
    public interface IDockLayout : Microsoft.Maui.ILayout {
        double ColumnSpacing { get; }
        double RowSpacing { get; }
        bool StretchLastChild { get; }
        Dock GetDock(IView view);
    }
    public class DockLayout : Layout, IDockLayout {
        public static readonly BindableProperty DockProperty = BindableProperty.CreateAttached("Dock", typeof(Dock), typeof(DockLayout), Dock.Left,
            propertyChanged: (x, o, n) => InvalidateMeasure(x));
        public static readonly BindableProperty ColumnSpacingProperty = BindableProperty.CreateAttached(nameof(ColumnSpacing), typeof(double), typeof(DockLayout), 0d,
            propertyChanged: (x, o, n) => ((DockLayout)x).InvalidateMeasureWithChildren());
        public static readonly BindableProperty RowSpacingProperty = BindableProperty.CreateAttached(nameof(RowSpacing), typeof(double), typeof(DockLayout), 0d,
            propertyChanged: (x, o, n) => ((DockLayout)x).InvalidateMeasureWithChildren());
        public static readonly BindableProperty StretchLastChildProperty = BindableProperty.CreateAttached(nameof(StretchLastChild), typeof(bool), typeof(DockLayout), true,
            propertyChanged: (x, o, n) => ((DockLayout)x).InvalidateMeasureWithChildren());
        static void InvalidateMeasure(BindableObject x) {
            if (x is not View view) return;
            if (view.Parent is not DockLayout layout) return;
            layout.InvalidateMeasureWithChildren();
        }

        public static Dock GetDock(View view) => (Dock)view.GetValue(DockProperty);
        public static void SetDock(View view, Dock value) => view.SetValue(DockProperty, value);
        public double ColumnSpacing { get => (double)GetValue(ColumnSpacingProperty); set => SetValue(ColumnSpacingProperty, value); }
        public double RowSpacing { get => (double)GetValue(RowSpacingProperty); set => SetValue(RowSpacingProperty, value); }
        public bool StretchLastChild { get => (bool)GetValue(StretchLastChildProperty); set => SetValue(StretchLastChildProperty, value); }

        protected override ILayoutManager CreateLayoutManager() {
            return new DockLayoutManager(this);
        }
        void InvalidateMeasureWithChildren() {
            InvalidateMeasure();
            foreach (var child in Children)
                child.InvalidateMeasure();
        }

        Dock IDockLayout.GetDock(IView view) => GetDock((View)view);
    }
    public class DockLayoutManager : LayoutManager {
        public static Size Measure<TChild>(
            double avWidth, double avHeight, double columnSpacing, double rowSpacing,
            Func<TChild, Dock> getDock,
            Func<TChild, Size, Size> measure,
            IEnumerable<TChild> children) {

            var resW = 0d;
            var resH = 0d;
            var w = 0d;
            var h = 0d;

            var i_last = children.Count() - 1;
            bool singleChild = i_last == 0;
            var i = 0;
            foreach(var child in children) {
                var childS = new Size(Math.Max(0, avWidth - w), Math.Max(0, avHeight - h));
                var childDS = measure(child, childS);
                bool isLastChild = i == i_last;
                var dock = getDock(child);
                switch(dock) {
                    case Dock.Left:
                    case Dock.Right:
                        w += childDS.Width;
                        if(!singleChild && !isLastChild)
                            w += columnSpacing;
                        resH = Math.Max(resH, h + childDS.Height);
                        break;
                    case Dock.Top:
                    case Dock.Bottom:
                        h += childDS.Height;
                        if(!singleChild && !isLastChild)
                            h += rowSpacing;
                        resW = Math.Max(resW, w + childDS.Width);
                        break;
                }
                i++;
            }
            resW = Math.Max(resW, w);
            resH = Math.Max(resH, h);
            if(resW > avWidth) resW = avWidth;
            if(resH > avHeight) resH = avHeight;
            return new Size(resW, resH);
        }
        public static Size Arrange<TChild>(
            Point p, double avWidth, double avHeight, double columnSpacing, double rowSpacing, bool stretchLastChild,
            Func<TChild, Dock> getDock,
            Func<TChild, Size> getDesiredSize,
            Action<TChild, Point, Size> arrange,
            IEnumerable<TChild> children) {

            var l = 0d;
            var t = 0d;
            var r = 0d;
            var b = 0d;

            var i_last = children.Count() - 1;
            bool singleChild = i_last == 0;
            var i = 0;
            foreach(var child in children) { 
                var childDS = getDesiredSize(child);
                var childP = new Point(l, t);
                var childS = new Size(Math.Max(0, avWidth - (l + r)), Math.Max(0, avHeight - (t + b)));

                bool isLastChild = i == i_last;
                bool stretch = stretchLastChild && isLastChild;
                var dock = getDock(child);
                if(!stretch) {
                    switch(dock) {
                        case Dock.Left:
                            l += childDS.Width;
                            if(!singleChild && !isLastChild)
                                l += columnSpacing;
                            childS.Width = childDS.Width;
                            break;
                        case Dock.Right:
                            r += childDS.Width;
                            childP.X = Math.Max(0, avWidth - r);
                            if(!singleChild && !isLastChild)
                                r += columnSpacing;
                            childS.Width = childDS.Width;
                            break;
                        case Dock.Top:
                            t += childDS.Height;
                            if(!singleChild && !isLastChild)
                                t += rowSpacing;
                            childS.Height = childDS.Height;
                            break;
                        case Dock.Bottom:
                            b += childDS.Height;
                            childP.Y = Math.Max(0, avHeight - b);
                            if(!singleChild && !isLastChild)
                                b += rowSpacing;
                            childS.Height = childDS.Height;
                            break;
                    }
                }

                childP.X += p.X;
                childP.Y += p.Y;
                arrange(child, childP, childS);
                i++;
            }
            return new Size(avWidth, avHeight);
        }

        public DockLayoutManager(IDockLayout layout) : base(layout) { }
        public new IDockLayout Layout => (IDockLayout)base.Layout;

        public override Size Measure(double widthConstraint, double heightConstraint) {
            var padding = Layout.Padding;
            var avW = Math.Max(0, widthConstraint - padding.HorizontalThickness);
            var avH = Math.Max(0, heightConstraint - padding.VerticalThickness);

            var children = Layout.Where(x => x.Visibility != Visibility.Collapsed).ToList();
            var res = Measure<IView>(
                avW, avH,
                Layout.ColumnSpacing, Layout.RowSpacing,
                x => Layout.GetDock(x),
                (x, s) => x.Measure(s.Width, s.Height),
                children);

            res.Width += padding.HorizontalThickness;
            res.Height += padding.VerticalThickness;

            res.Width = ResolveConstraints(widthConstraint, Layout.Width, res.Width, Layout.MinimumWidth, Layout.MaximumWidth);
            res.Height = ResolveConstraints(heightConstraint, Layout.Height, res.Height, Layout.MinimumHeight, Layout.MaximumHeight);

            return res;
        }
        public override Size ArrangeChildren(Rect bounds) {
            var padding = Layout.Padding;
            var avW = Math.Max(0, bounds.Width - padding.HorizontalThickness);
            var avH = Math.Max(0, bounds.Height - padding.VerticalThickness);
            var x = bounds.X + padding.Left;
            var y = bounds.Y + padding.Top;

            var children = Layout.Where(x => x.Visibility != Visibility.Collapsed).ToList();
            var res = Arrange<IView>(
                new Point(x, y), avW, avH, 
                Layout.ColumnSpacing, Layout.RowSpacing, Layout.StretchLastChild,
                x => Layout.GetDock(x),
                x => x.DesiredSize,
                (x, p, s) => x.Arrange(new Rect(p, s)),
                children);

            res.Width += padding.Right;
            res.Height += padding.Bottom;

            return res.AdjustForFill(bounds, Layout);
        }
    }

    public class ScrollViewFix : ScrollView {
        protected override void OnChildAdded(Element child) {
            ((VisualElement)child).SizeChanged += OnContentSizeChanged;
        }

        protected override void OnChildRemoved(Element child, int oldLogicalIndex) {
            ((VisualElement)child).SizeChanged -= OnContentSizeChanged;
        }

        void OnContentSizeChanged(object sender, EventArgs e) {
            InvalidateMeasure();
        }
    }
}

