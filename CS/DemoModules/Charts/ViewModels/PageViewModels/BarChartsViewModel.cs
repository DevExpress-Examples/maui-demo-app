using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class BarChartsViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new BarChartItemInfoContainer(
                viewModel: new SideBySideRangeBarChartViewModel(),
                type: BarType.SideBySideRange
            ),
            new BarChartItemInfoContainer(
                viewModel: new RangeBarChartViewModel(),
                type: BarType.Range
            ),
            new BarChartItemInfoContainer(
                viewModel: new PopulationPyramidViewModel(),
                type: BarType.PopulationPyramid
            ),
            new BarChartItemInfoContainer(
                viewModel: new BarChartViewModel(),
                type: BarType.Simple
            ),
            new BarChartItemInfoContainer(
                viewModel: new StackedBarChartViewModel(),
                type: BarType.Stacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new SideBySideStackedBarChartViewModel(),
                type: BarType.SideBySideStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new FullStackedBarChartViewModel(),
                type: BarType.FullStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new SideBySideStackedBarChartViewModel(),
                type: BarType.SideBySideFullStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new StackedBarChartViewModel(),
                type: BarType.RotatedStacked
            ),
            new BarChartItemInfoContainer(
                viewModel: new SideBySideStackedBarChartViewModel(),
                type: BarType.RotatedSideBySide
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class BarChartItemInfoContainer : ChartItemInfoContainerBase {
        public BarType BarType { get; }

        public BarChartItemInfoContainer(BarType type, ChartViewModelBase viewModel) {
            BarType = type;
            ChartModel = viewModel;
        }
    }
}
