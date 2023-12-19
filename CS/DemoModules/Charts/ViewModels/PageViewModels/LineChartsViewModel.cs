using System;
using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;
namespace DemoCenter.Maui.Charts.ViewModels {
    public class DataItem {
        public DateTime Argument { get; }
        public double Value { get; }

        public DataItem(DateTime argument, double value) {
            Argument = argument;
            Value = value;
        }
    }

    public class LineChartsViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new LineChartItemInfoContainer(
                viewModel: new LineChartViewModel(),
                type: LineType.Simple
            ),
            new LineChartItemInfoContainer(
                viewModel: new SplineChartViewModel(),
                type: LineType.Spline
            ),
            new LineChartItemInfoContainer(
                viewModel: new ScatterLineChartViewModel(),
                type: LineType.Scatter
            ),
            new LineChartItemInfoContainer(
                viewModel: new StepLineChartViewModel(),
                type: LineType.Step
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class LineChartItemInfoContainer : ChartItemInfoContainerBase {
        public LineChartItemInfoContainer(LineType type, ChartViewModelBase viewModel) {
            this.LineType = type;
            this.ChartModel = viewModel;
        }
        public LineType LineType { get; set; }
        public string LineTypeImage {
            get {
                switch (LineType) {
                    case LineType.Simple:
                        return GetThemedImageName("demochartsline");
                    case LineType.Scatter:
                        return GetThemedImageName("demochartsscatter");
                    case LineType.Step:
                        return GetThemedImageName("demochartsstepline");
                    case LineType.Spline:
                        return GetThemedImageName("demochartsspline");
                    default:
                        throw new ArgumentException("The selector cannot handle the passed LineType value.");
                }
            }
        }
    }
}
