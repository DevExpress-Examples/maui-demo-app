using System.Collections.Generic;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {
    public class BubbleColorizerViewModel : ChartViewModelBase {
        readonly HpiIndexCustomColorizerAdapter dataAdapter = new HpiIndexCustomColorizerAdapter();

        public override string Title => "Bubble colorizer";
        public List<CountryStatistic> CountriesStatisticData => this.dataAdapter.SeriesData;
    }

    public class BarColorizerViewModel : ChartViewModelBase {
        CountriesStatisticData data = new CountriesStatisticData();

        public override string Title => "Bar colorizer";
        public List<CountryStatistic> CountriesStatisticData => this.data.SeriesData;
    }

    public class OperationSurfaceTemperatureViewModel : ChartViewModelBase {
        TemperatureData data = new TemperatureData();

        public override string Title => "Operation Surface Temperature";
        public double OptimalTemperature => this.data.OptimalTemperature;
        public List<TemperaturePoint> TemperaturePoints => this.data.SeriesData;
    }

    public class GradientSegmentColorizerViewModel : ChartViewModelBase {
        LightSpectorData data = new LightSpectorData();

        public override string Title => "Light Spector";
        public IList<NumericData> LightSpectorData => this.data.LightSpectors;
    }

    public class AreaGradientFillEffectViewModel : ChartViewModelBase {
        public StockPrices StockPrices { get; }

        public override string Title => "Stock Prices";

        public AreaGradientFillEffectViewModel() {
            StockPrices = StockData.GetStockPrices();
        }
    }
}
