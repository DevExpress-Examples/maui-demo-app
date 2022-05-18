using System;
using System.Collections.Generic;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;

namespace DemoCenter.Maui.ViewModels {
    public class LineChartViewModel : ChartViewModelBase {
        readonly TrendPopulationData trendPopulationData = new TrendPopulationData();

        public override string Title => "Historic, Current and Future Population";

        public DataSetContainer<DateTimeData> Europe => trendPopulationData.Europe;
        public DataSetContainer<DateTimeData> Americas => trendPopulationData.Americas;
        public DataSetContainer<DateTimeData> Africa => trendPopulationData.Africa;

        public DateTime CurrentDate => DateTime.Now;
    }

    public class ScatterLineChartViewModel : ChartViewModelBase {
        readonly ArchimedeanSpiralSeriesData seriesData = new ArchimedeanSpiralSeriesData();

        public override string Title => "Function in Cartesian Coordinates";
        public ArchimedeanSpiralSeriesData SeriesData => seriesData;
    }

    public class StepLineChartViewModel : ChartViewModelBase {
        readonly AverageDieselPricesData chartData = new AverageDieselPricesData();

        public override string Title => "U.S. Average Diesel Prices";
        public DataSetContainer<DateTimeData> DieselPrices => chartData.DieselPrices;
    }

    public class SplineChartViewModel : ChartViewModelBase {
        readonly SplineData chartData = new SplineData();
        readonly DateTimeRange visualRange;

        public DateTimeRange VisualRange => visualRange;
        public override string Title => "Energy Released by Earthquakes";
        public IList<DateTimeData> SeriesData => chartData.SeriesData;

        public SplineChartViewModel() {
            visualRange = new DateTimeRange() { VisualMin = new DateTime(1999, 1, 1), VisualMax = new DateTime(1999, 5, 1), SideMargin = 10 };
        }
    }
}

