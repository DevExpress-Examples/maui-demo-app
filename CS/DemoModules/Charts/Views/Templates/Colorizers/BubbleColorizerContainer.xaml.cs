using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Charts.Views {
    public partial class BubbleColorizerContainer : ContentView {
        public BubbleColorizerContainer() {
            
            InitializeComponent();
        }

        void OnBubbleColorizerChanged(object sender, DevExpress.Maui.Charts.SelectionChangedEventArgs e) {
            if (e.SelectedObjects.Count > 0 && e.SelectedObjects[0] is DataSourceKey dataSourceKey) {
                if (dataSourceKey.DataObject is CountryStatistic countryStatistic) {
                    series.HintOptions = new SeriesHintOptions();
                    series.HintOptions.PointTextPattern = string.Format("{0}\nGDP per capita: {1:0}$\nPopulation: {2:0.00}M\nHPI: {3:0.00}",
                                                                                countryStatistic.Country,
                                                                                countryStatistic.Gdp,
                                                                                countryStatistic.Population / 1000000,
                                                                                countryStatistic.Hpi);
                    chart.ShowHint(0, dataSourceKey.Index);
                }
            }
        }
    }
}
