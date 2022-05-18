using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class PieChartsViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new PieChartItemInfoContainer(
                viewModel: new DonutChartViewModel(),
                type: PieType.Donut
            ),
            new PieChartItemInfoContainer(
                viewModel: new PieChartViewModel(),
                type: PieType.Pie
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class PieChartItemInfoContainer: ChartItemInfoContainerBase {
        public PieType PieType { get; set; }
        public PieChartItemInfoContainer(PieType type, ChartViewModelBase viewModel) {
            this.PieType = type;
            this.ChartModel = viewModel;
        }
    }
}
