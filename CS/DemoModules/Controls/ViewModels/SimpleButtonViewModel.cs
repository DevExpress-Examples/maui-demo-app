using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class SimpleButtonViewModel : NotificationObject {
        double DefaultCornerRadius = 4.0;
        double DefaultBorderSize = 4.0;

        ColorViewModel selectedTextColor;
        ColorViewModel selectedBackgroundColor;
        ColorViewModel selectedIconColor;
        ColorViewModel selectedBorderColor;

        double topLeftCornerRadius;
        double topRightCornerRadius;
        double bottomLeftCornerRadius;
        double bottomRightCornerRadius;
        Microsoft.Maui.CornerRadius cornerRadius;
        double borderWidth;

        bool shouldShowIcon;
        bool shouldShowBorder;
        bool shouldShowShadow;

        public IList<ColorViewModel> Colors { get; }
        public ColorViewModel SelectedTextColor { get => selectedTextColor; set => SetProperty(ref selectedTextColor, value); }
        public ColorViewModel SelectedBackgroundColor { get => selectedBackgroundColor; set => SetProperty(ref selectedBackgroundColor, value); }
        public ColorViewModel SelectedIconColor { get => selectedIconColor; set => SetProperty(ref selectedIconColor, value); }
        public ColorViewModel SelectedBorderColor { get => selectedBorderColor; set => SetProperty(ref selectedBorderColor, value); }

        public bool ShouldShowIcon { get => shouldShowIcon; set => SetProperty(ref shouldShowIcon, value); }
        public bool ShouldShowBorder {
            get => shouldShowBorder;
            set => SetProperty(ref shouldShowBorder, value, () => BorderWidth = ShouldShowBorder ? DefaultBorderSize : 0);
        }
        public bool ShouldShowShadow { get => shouldShowShadow; set => SetProperty(ref shouldShowShadow, value); }

        public double TopLeftCornerRadius { get => topLeftCornerRadius; set => SetProperty(ref topLeftCornerRadius, value, UpdateCornerRadius); }
        public double TopRightCornerRadius { get => topRightCornerRadius; set => SetProperty(ref topRightCornerRadius, value, UpdateCornerRadius); }
        public double BottomLeftCornerRadius { get => bottomLeftCornerRadius; set => SetProperty(ref bottomLeftCornerRadius, value, UpdateCornerRadius); }
        public double BottomRightCornerRadius { get => bottomRightCornerRadius; set => SetProperty(ref bottomRightCornerRadius, value, UpdateCornerRadius); }
        public Microsoft.Maui.CornerRadius CornerRadius { get => cornerRadius; set => SetProperty(ref cornerRadius, value); }
        public double BorderWidth { get => borderWidth; set => SetProperty(ref borderWidth, value); }

        public SimpleButtonViewModel() {
            Colors = ColorViewModel.CreateDefaultColors();
            SelectedTextColor = Colors[0];
            SelectedBackgroundColor = Colors[6];
            SelectedIconColor = Colors[0];
            SelectedBorderColor = Colors[1];

            TopLeftCornerRadius = DefaultCornerRadius;
            TopRightCornerRadius = DefaultCornerRadius;
            BottomLeftCornerRadius = DefaultCornerRadius;
            BottomRightCornerRadius = DefaultCornerRadius;
        }

        void UpdateCornerRadius() {
            CornerRadius = new Microsoft.Maui.CornerRadius(TopLeftCornerRadius, TopRightCornerRadius, BottomLeftCornerRadius, BottomRightCornerRadius);
        }
    }
}
