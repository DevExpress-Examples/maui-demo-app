using System.ComponentModel;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;

namespace DemoCenter.Maui.ViewModels {
    public class RealTimeDataViewModel : ChartViewModelBase {
        readonly RealTimeDataProvider dataProvider;

        public RealTimeDataViewModel(ChartView chart) {
            this.dataProvider = new RealTimeDataProvider(chart);
        }

        public BindingList<DateTimeData> XAxisData => dataProvider.XAxisSeriesData;
        public BindingList<DateTimeData> YAxisData => dataProvider.YAxisSeriesData;
        public BindingList<DateTimeData> ZAxisData => dataProvider.ZAxisSeriesData;

        public void Stop() {
            dataProvider.Stop();
        }

        public void Start() {
            dataProvider.Start();
        }
    }
}
