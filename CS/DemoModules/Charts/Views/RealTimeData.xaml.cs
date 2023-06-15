using DevExpress.Maui.Core;
using DevExpress.Maui.Core.Internal;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class RealTimeData : Demo.DemoPage {
        RealTimeDataViewModel viewModel;
        readonly static bool IsOniOSSimulator = ON.Simulator && ON.iOS;
        public RealTimeData() {
            InitializeComponent();
            BindingContext = viewModel = new RealTimeDataViewModel(chart);
        }
        protected override void OnDisappearing() {
            base.OnDisappearing();
            if (!IsOniOSSimulator) {
                viewModel.Stop();
            }
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            if (!IsOniOSSimulator) {
                viewModel.Start();
            } else {
                DisplayAlert("Accelerometer not found", "This demo is available only on the real device.", "Ok");
            }
        }
    }
}
