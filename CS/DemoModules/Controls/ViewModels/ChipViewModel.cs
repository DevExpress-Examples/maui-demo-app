using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class ChipDataObject {
        public ImageSource Image { get; }
        public string Text { get; }

        public ChipDataObject(string text) {
            Text = text;
            Image = ImageSource.FromFile("smile");
        }
    }

    public class ChipViewModel : NotificationObject {
        Microsoft.Maui.CornerRadius DefaultCornerRadius = new Microsoft.Maui.CornerRadius(-1);
        double DefaultBorderSize = 2.0;

        ColorViewModel selectedTextColor;
        ColorViewModel selectedBackgroundColor;
        ColorViewModel selectedIconColor;
        ColorViewModel selectedBorderColor;

        double customCornerRadius;
        Microsoft.Maui.CornerRadius cornerRadius;
        double borderWidth;

        bool shouldShowIcon;
        bool shouldShowBorder;
        bool useCustomCornerRadius;
        bool removeIconVisible;

        public IList<ColorViewModel> Colors { get; }
        public IList<ChipDataObject> Items { get; }
        public ColorViewModel SelectedTextColor { get => selectedTextColor; set => SetProperty(ref selectedTextColor, value); }
        public ColorViewModel SelectedBackgroundColor { get => selectedBackgroundColor; set => SetProperty(ref selectedBackgroundColor, value); }
        public ColorViewModel SelectedIconColor { get => selectedIconColor; set => SetProperty(ref selectedIconColor, value); }
        public ColorViewModel SelectedBorderColor { get => selectedBorderColor; set => SetProperty(ref selectedBorderColor, value); }

        public bool ShouldShowIcon { get => shouldShowIcon; set => SetProperty(ref shouldShowIcon, value); }
        public bool ShouldShowBorder {
            get => shouldShowBorder;
            set => SetProperty(ref shouldShowBorder, value, () => BorderWidth = ShouldShowBorder ? DefaultBorderSize : 0);
        }

        public bool UseCustomCornerRadius {
            get => useCustomCornerRadius;
            set => SetProperty(ref useCustomCornerRadius, value, () => {
                UpdateCornerRadius();
                CustomCornerRadius = 0;
            });
        }

        public double CustomCornerRadius {
            get => customCornerRadius;
            set => SetProperty(ref customCornerRadius, value, () => UpdateCornerRadius());
        }

        public Microsoft.Maui.CornerRadius CornerRadius { get => cornerRadius; set => SetProperty(ref cornerRadius, value); }
        public double BorderWidth { get => borderWidth; set => SetProperty(ref borderWidth, value); }
        public bool RemoveIconVisible { get => removeIconVisible; set => SetProperty(ref removeIconVisible, value); }

        public ChipViewModel() {
            cornerRadius = DefaultCornerRadius;
            Colors = ColorViewModel.CreateDefaultColors();
            Items = new List<ChipDataObject>() {
                new ChipDataObject("Chip 1"),
                new ChipDataObject("Chip 2"),
                new ChipDataObject("Chip 3"),
                new ChipDataObject("Chip 4"),
                new ChipDataObject("Chip 5"),
                new ChipDataObject("Chip 6")
            };
            SelectedTextColor = Colors[0];
            SelectedBackgroundColor = Colors[6];
            SelectedIconColor = Colors[0];
            SelectedBorderColor = Colors[1];
        }

        void UpdateCornerRadius() {
            CornerRadius = UseCustomCornerRadius? new Microsoft.Maui.CornerRadius(CustomCornerRadius) : DefaultCornerRadius;
        }
    }
}
