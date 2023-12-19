using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class FinancialChart : Demo.DemoPage {
        public FinancialChart() {

            InitializeComponent();
            BindingContext = new FinancialChartViewModel();
        }
    }
}
