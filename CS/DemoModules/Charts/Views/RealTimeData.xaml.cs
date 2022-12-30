using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Devices;
using ON = DevExpress.Maui.Core.Internal.On;

namespace DemoCenter.Maui.Views {
    public partial class RealTimeData : Demo.DemoPage {
        RealTimeDataViewModel viewModel;
        readonly static bool IsOniOSSimulator = DeviceInfo.DeviceType == DeviceType.Virtual && ON.IOS;
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
