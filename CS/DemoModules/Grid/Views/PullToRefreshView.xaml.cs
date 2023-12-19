using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class PullToRefreshView : BaseGridContentPage {
        public PullToRefreshView() {
            InitializeComponent();
        }
        protected override object LoadData() {
            MainGridViewModel viewModel = new MainGridViewModel(new GridOrdersRepository());
            viewModel.ForceSimulateMarketWorker();
            return viewModel;
        }
    }
}
