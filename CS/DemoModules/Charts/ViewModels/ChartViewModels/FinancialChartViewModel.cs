using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;

namespace DemoCenter.Maui.ViewModels {
    public class FinancialChartViewModel : ChartViewModelBase {
        
        readonly DateTimeRange visualRange;

        public StockPrices StockPrices { get; }
        public DateTimeRange VisualRange => visualRange;

        public FinancialChartViewModel() {
            StockPrices = StockData.GetStockPrices();
            visualRange = new DateTimeRange() { VisualMin = new System.DateTime(2020, 04, 7), VisualMax = new System.DateTime(2020, 07, 7) };
        }
    }
}
