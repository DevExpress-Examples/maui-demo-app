using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class FinancialChart : Demo.DemoPage {
		public FinancialChart() {
            
            InitializeComponent();
            BindingContext = new FinancialChartViewModel();
        }
    }
}
