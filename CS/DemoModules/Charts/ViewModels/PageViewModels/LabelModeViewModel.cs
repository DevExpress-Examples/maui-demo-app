using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class LabelModeViewModel : ChartsPageViewModelBase{
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new AxisLabelOptionsItemInfoContainer(
                viewModel: new AxisLabelOptionsViewModel(),
                type: AxisLabelOptionsType.RotatedAndStaggered
            ),
            new AxisLabelOptionsItemInfoContainer(
                viewModel: new CryptocurrencyPortfolioViewModel(),
                type: AxisLabelOptionsType.CryptocurrencyPortfolio
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class AxisLabelOptionsItemInfoContainer : ChartItemInfoContainerBase {
        public AxisLabelOptionsType LabelModeType { get; }

        public AxisLabelOptionsItemInfoContainer(AxisLabelOptionsType type, ChartViewModelBase viewModel) {
            LabelModeType = type;
            ChartModel = viewModel;
        }
    }
}
