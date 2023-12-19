using DemoCenter.Maui.Charts.ViewModels;
using DevExpress.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class PointsCharts : Demo.DemoPage {
        public PointsCharts() {
            InitializeComponent();
            BindingContext = new PointChartsViewModel();
            SizeChanged += (s, e) => UpdateOrientation(Width, Height);
            UpdateOrientation(Width, Height);
        }

        void UpdateOrientation(double width, double height) {
            bool isVertical = width <= height;
            HeaderContentPosition position = isVertical ? HeaderContentPosition.Top : HeaderContentPosition.Left;
            dxTabView.HeaderPanelPosition = position;
            ((ChartsPageViewModelBase)BindingContext).SetVerticalState(isVertical);
        }
    }
}
