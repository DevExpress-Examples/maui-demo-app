using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class FinancialChart : ContentPage {
		public FinancialChart() {
            
            InitializeComponent();
            BindingContext = new FinancialChartViewModel();
        }
    }
}
