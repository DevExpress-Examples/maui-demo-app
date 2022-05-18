using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Charts.Views {
    public partial class BubbleChartContainer : ContentView {
		public BubbleChartContainer() {
            
            InitializeComponent();
		}

        void OnBubbleSelectionChanged(object sender, DevExpress.Maui.Charts.SelectionChangedEventArgs e) {
            if (e.SelectedObjects.Count > 0 && e.SelectedObjects[0] is DataSourceKey dataSourceKey) {
                if (dataSourceKey.DataObject is FilmData bubbleDataObject) {
                    bubbleSeries.HintOptions = new SeriesHintOptions();
                    bubbleSeries.HintOptions.PointTextPattern = bubbleDataObject.Name + "\nProduction budget: {V$$#M}\nWordwide grosses: {W$$#.##B}";
                    bubbleChart.ShowHint(0, dataSourceKey.Index);
                }
            }
        }
    }
}
