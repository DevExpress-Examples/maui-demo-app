using System.Collections.Generic;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class SimpleButtonViewModel : NotificationObject {
        
        double DefaultBorderSize = 4.0;

        ColorViewModel selectedTextColor;
        ColorViewModel selectedBackgroundColor;
        ColorViewModel selectedIconColor;
        ColorViewModel selectedBorderColor;

        
        
        
        
        
        double borderWidth;
        bool shouldShowIcon;
        bool shouldShowBorder;

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

        
        
        
        
        
        public double BorderWidth { get => borderWidth; set => SetProperty(ref borderWidth, value); }

        public SimpleButtonViewModel() {
            Colors = ColorViewModel.CreateDefaultColors();
            SelectedTextColor = Colors[0];
            SelectedBackgroundColor = Colors[6];
            SelectedIconColor = Colors[0];
            SelectedBorderColor = Colors[1];

            
            
            
            
        }

        
        
        
    }
}
