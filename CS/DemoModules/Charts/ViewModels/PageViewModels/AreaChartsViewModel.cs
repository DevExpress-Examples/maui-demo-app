using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class AreaChartsViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new AreaChartItemInfoContainer(
                viewModel: new RangeAreaChartViewModel(),
                type: AreaType.Range
            ),
            new AreaChartItemInfoContainer(
                viewModel: new AreaChartViewModel(),
                type: AreaType.Simple
            ),
            new AreaChartItemInfoContainer(
                viewModel: new StackedAreaChartViewModel(),
                type: AreaType.Stacked
            ),
            new AreaChartItemInfoContainer(
                viewModel: new FullStackedAreaChartViewModel(),
                type: AreaType.FullStacked
            ),
            new AreaChartItemInfoContainer(
                viewModel: new StepAreaChartViewModel(),
                type: AreaType.Step
            ) 
        };
        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class AreaChartItemInfoContainer: ChartItemInfoContainerBase {
        public AreaType AreaType { get; set; }
        public AreaChartItemInfoContainer(AreaType type, ChartViewModelBase viewModel) {
            this.AreaType = type;
            this.ChartModel = viewModel;
        }
    }    
}
