using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class RealTimeDataView : BaseGridContentPage {
        MainGridViewModel ViewModel { get; set; }
        public RealTimeDataView() {
            AddResources();
            InitializeComponent();

            this.Disappearing += Handle_Disappearing;
        }

        void AddResources() {
            double fontSize;
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                fontSize = 14.0;
            } else {
                fontSize = 12.0;
            }
            Resources.Add("FontSize", fontSize);
        }

        protected override object LoadData() {
            ViewModel = new MainGridViewModel(new GridOrdersRepository());
            ViewModel.ForceSimulateMarketWorker();
            ViewModel.StartMarketSimulation();
            return ViewModel;
        }

        void Handle_Disappearing(object sender, EventArgs e) {
            ViewModel?.StopMarketSimulation();
        }
    }
}
