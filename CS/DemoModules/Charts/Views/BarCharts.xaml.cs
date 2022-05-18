using DemoCenter.Maui.Charts.ViewModels;
using DevExpress.Maui.Controls;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class BarCharts : ContentPage {
        public BarCharts() {
            InitializeComponent();
            BindingContext = new BarChartsViewModel();
            SizeChanged += (s, e) => UpdateOrientation(Width, Height);
            UpdateOrientation(Width, Height);
        }
        void UpdateOrientation(double width, double height) {
            bool isVertical = width <= height;
            Position position = isVertical ? Position.Top: Position.Left;
            dxTabView.HeaderPanelPosition = position;
            ((ChartsPageViewModelBase)BindingContext).SetVerticalState(isVertical);
        }
    }
}
