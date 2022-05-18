using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Charts.ViewModels {
    public class ChartItemInfoContainerBase : NotificationObject {
        bool isSelected;
        bool isVertical;
        public bool IsSelected {
            get => isSelected;
            set => SetProperty(ref isSelected, value);
        }
        public bool IsVertical {
            get => isVertical;
            set => SetProperty(ref isVertical, value);
        }
        public ChartViewModelBase ChartModel {
            get;
            protected set;
        }
    }
}
