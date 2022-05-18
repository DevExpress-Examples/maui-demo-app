using System.Collections.Generic;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {
    public class AxisLabelOptionsViewModel : ChartViewModelBase {
        readonly PopulationByCountryData data;

        public IList<QualitativeData> PopulationByCountry => data.SeriesData;

        public AxisLabelOptionsViewModel() {
            data = new PopulationByCountryData();
        }
    }
}
