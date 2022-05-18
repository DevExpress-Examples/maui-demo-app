using System.Collections.Generic;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {
    public class AreaChartViewModel : ChartViewModelBase {
        readonly OutsideVendorCostsData chartData = new OutsideVendorCostsData();

        public override string Title => "Vendor Costs";
        public DataSetContainer<DateTimeData> DevAVNorth => chartData.DevAVNorth;
        public DataSetContainer<DateTimeData> DevAVSouth => chartData.DevAVSouth;
    }

    public class RangeAreaChartViewModel : ChartViewModelBase {
        readonly RangeAreaData chartData = new RangeAreaData();

        public override string Title => "Richmond vs Houston Temperatures";
        public List<RangeDateTimeData> RichmondWeatherData => chartData.SeriesData[0];
        public List<RangeDateTimeData> HoustonWeatherData => chartData.SeriesData[1];
    }

    public class StackedAreaChartViewModel : ChartViewModelBase {
        readonly SalesByLastYearsData chartData = new SalesByLastYearsData();

        public override string Title => "DevAV Sales";
        public DataSetContainer<DateTimeData> NorthAmerica => chartData.NorthAmerica;
        public DataSetContainer<DateTimeData> Europe => chartData.Europe;
        public DataSetContainer<DateTimeData> Australia => chartData.Australia;
    }

    public class FullStackedAreaChartViewModel : ChartViewModelBase {
        readonly BranchesSalesData chartData = new BranchesSalesData();

        public override string Title => "Market Share Over Time";
        public DataSetContainer<DateTimeData> DevAVEast => chartData.DevAVEast;
        public DataSetContainer<DateTimeData> DevAVWest => chartData.DevAVWest;
        public DataSetContainer<DateTimeData> DevAVSouth => chartData.DevAVSouth;
        public DataSetContainer<DateTimeData> DevAVCenter => chartData.DevAVCenter;
        public DataSetContainer<DateTimeData> DevAVNorth => chartData.DevAVNorth;
    }

    public class StepAreaChartViewModel : ChartViewModelBase {
        readonly AverageDieselPricesData chartData = new AverageDieselPricesData();

        public override string Title => "U.S. Average Diesel Prices";
        public DataSetContainer<DateTimeData> DieselPrices => chartData.DieselPrices;
    }
}
