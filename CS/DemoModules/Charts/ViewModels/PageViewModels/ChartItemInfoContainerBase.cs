using DemoCenter.Maui.ViewModels;
using MThemeLoader = DemoCenter.Maui.Styles.ThemeLoader.ThemeLoader;
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
        protected string GetThemedImageName(string imageName) {
            return MThemeLoader.ThemeName.ToLower() + imageName;
        }
    }
}
