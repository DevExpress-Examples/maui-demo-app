using System.Collections.Generic;
using DemoCenter.Maui.Data;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class SelectionViewModel : ChartViewModelBase {
        readonly SalesByYearsData salesByYears;
        readonly Color[] palette = PaletteLoader.LoadPalette("#FF42A5F5", "#FFFF5252", "#FF4CAF50", "#FFFFAB40", "#FFBDBDBD");

        public IList<PieData> PieSeriesData => salesByYears.PieData;
        public IList<List<DateTimeData>> SeriesDataByYears => salesByYears.Data;
        public Color[] Palette => palette;

        public SelectionViewModel() {
            salesByYears = new SalesByYearsData();
        }
    }
}
