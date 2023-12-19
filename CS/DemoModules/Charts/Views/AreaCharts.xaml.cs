using DemoCenter.Maui.Charts.ViewModels;
using DevExpress.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class AreaCharts : Demo.DemoPage {
        public AreaCharts() {
            InitializeComponent();
            BindingContext = new AreaChartsViewModel();
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
