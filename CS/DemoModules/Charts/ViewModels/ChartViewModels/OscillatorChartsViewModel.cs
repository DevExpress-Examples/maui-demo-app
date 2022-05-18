using System.Collections.Generic;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {
    public class OscillatorChartsViewModel : ChartViewModelBase {
        readonly OscillatorDataProvider dataProvider = new OscillatorDataProvider();
        List<NumericData> oscillatorSeriesData = null;

        public List<NumericData> OscillatorSeriesData {
            get => oscillatorSeriesData;
            set => SetProperty(ref oscillatorSeriesData, value);
        }

        public OscillatorChartsViewModel() {
            MoveToNextFrame();
        }

        public void MoveToNextFrame() {
            OscillatorSeriesData = dataProvider.GenerateNextData();
        }
    }
}
