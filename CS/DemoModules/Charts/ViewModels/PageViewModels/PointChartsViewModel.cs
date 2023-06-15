using System;
using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class PointChartsViewModel : ChartsPageViewModelBase {
        static readonly List<ChartItemInfoContainerBase> content = new List<ChartItemInfoContainerBase>() {
            new PointChartItemInfoContainer(
                viewModel: new PointChartViewModel(),
                type: PointType.Point
            ),
            new PointChartItemInfoContainer(
                viewModel: new BubbleChartViewModel(),
                type: PointType.Bubble
            )
        };

        public override List<ChartItemInfoContainerBase> Content => content;
    }

    public class PointChartItemInfoContainer: ChartItemInfoContainerBase {        
        public PointChartItemInfoContainer(PointType type, ChartViewModelBase viewModel) {
            this.PointType = type;
            this.ChartModel = viewModel;
        }
        public PointType PointType { get; set; }
        public string PointTypeImage {
            get {
                switch (PointType) {
                    case PointType.Point: return GetThemedImageName("demochartspoint");
                    case PointType.Bubble: return GetThemedImageName("demochartsbubble");
                    default: throw new ArgumentException("The selector cannot handle the passed PointType value.");
                }
            }
        }
    }
}
