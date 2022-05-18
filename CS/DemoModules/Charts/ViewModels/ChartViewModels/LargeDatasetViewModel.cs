using System;
using System.Windows.Input;
using DemoCenter.Maui.Data;
using DevExpress.Maui.Charts;

namespace DemoCenter.Maui.ViewModels {
    public class LargeDatasetViewModel : ChartViewModelBase {
        readonly AddSeriesCommand addSeriesCommand;
        readonly ChartView chart;

        int totalPointsCount;
        public int TotalPointsCount {
            get { return totalPointsCount; }
            set { SetProperty(ref totalPointsCount, value); }
        }
        public AddSeriesCommand AddSeries { get => addSeriesCommand; }

        public LargeDatasetViewModel(ChartView chart)
        {
            this.chart = chart;
            addSeriesCommand = new AddSeriesCommand((pointCount) => {
                LineSeries lineSeries = new LineSeries();
                lineSeries.Style = new LineSeriesStyle() { StrokeThickness = 1 };
                lineSeries.Data = new LargeDatasetSeriesData(pointCount);
                this.chart.Series.Add(lineSeries);
                TotalPointsCount += pointCount;
            });
            AddSeries.Execute(100000);
        }
    }

    public class AddSeriesCommand : ICommand {
        readonly Action<int> action;
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public AddSeriesCommand(Action<int> action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action(Convert.ToInt32(parameter));
    }
}
