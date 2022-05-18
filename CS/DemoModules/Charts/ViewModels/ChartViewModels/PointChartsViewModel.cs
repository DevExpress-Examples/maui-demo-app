using System.Collections.Generic;
using DemoCenter.Maui.Data;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class PointChartViewModel : ChartViewModelBase {
        readonly LondonWeatherData chartData = new LondonWeatherData();

        public DataSetContainer<DateTimeData> NightMin => chartData.NightMin;
        public DataSetContainer<DateTimeData> DayMax => chartData.DayMax;
        public int AverageTempNight => (int) chartData.NightMinAverageValue;
        public int AverageTempDay => (int) chartData.DayMaxAverageValue;

        public override string Title => "Average Temperature in London";
    }

    public class BubbleChartViewModel : ChartViewModelBase {
        HighestGrossingFilmsByYearData data = new HighestGrossingFilmsByYearData();

        public override string Title => "Highest-Grossing Films by Year";
        public List<FilmData> SeriesData => data.SeriesData;
        public Color[] Palette => Palettes.Extended;
    }
}
