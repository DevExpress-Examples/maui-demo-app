using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class RealTimeDataView : BaseGridContentPage {
        MainGridViewModel ViewModel { get; set; }
        public RealTimeDataView() {
            InitializeComponent();
            this.Disappearing += Handle_Disappearing;
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
