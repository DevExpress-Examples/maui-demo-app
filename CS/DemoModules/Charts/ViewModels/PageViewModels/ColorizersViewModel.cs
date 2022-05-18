using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class ColorizersViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new ColorizerItemInfoContainer(
                viewModel: new AreaGradientFillEffectViewModel(),
                type: CustomAppearanceType.AreaGradientFillEffect
            ),
            new ColorizerItemInfoContainer(
                viewModel: new BubbleColorizerViewModel(),
                type: CustomAppearanceType.Bubble
            ),
            new ColorizerItemInfoContainer(
                viewModel: new BarColorizerViewModel(),
                type: CustomAppearanceType.Bar
            ),
            new ColorizerItemInfoContainer(
                viewModel: new GradientSegmentColorizerViewModel(),
                type: CustomAppearanceType.GradientSegmentColorizer
            ),
            new ColorizerItemInfoContainer(
                viewModel: new OperationSurfaceTemperatureViewModel(),
                type: CustomAppearanceType.OperationSurfaceTemperature
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class ColorizerItemInfoContainer : ChartItemInfoContainerBase {
        public CustomAppearanceType CustomAppearanceModuleType { get; set; }

        public ColorizerItemInfoContainer(CustomAppearanceType type, ChartViewModelBase viewModel) {
            CustomAppearanceModuleType = type;
            ChartModel = viewModel;
        }

    }
}
