using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class RealTimeData : ContentPage {
        RealTimeDataViewModel viewModel;
        public RealTimeData() {
            
            InitializeComponent();
            BindingContext = viewModel = new RealTimeDataViewModel(chart);
        }
        protected override void OnDisappearing() {
            base.OnDisappearing();
            viewModel.Stop();
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            viewModel.Start();
        }
    }
}
