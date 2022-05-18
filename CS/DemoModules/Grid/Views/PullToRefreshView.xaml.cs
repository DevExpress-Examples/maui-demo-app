using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class PullToRefreshView : BaseGridContentPage {
        public PullToRefreshView() {
            AddResources();
            InitializeComponent();
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
            MainGridViewModel viewModel = new MainGridViewModel(new GridOrdersRepository());
            viewModel.ForceSimulateMarketWorker();
            return viewModel;
        }
    }
}
