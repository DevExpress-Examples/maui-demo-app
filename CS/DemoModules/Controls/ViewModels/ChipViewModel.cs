using System.Collections.Generic;
using System.Windows.Input;
using DemoCenter.Maui.ViewModels;
using DemoCenter.Maui.Views;
using DevExpress.Maui.Editors;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class ChipDataObject {
        public ImageSource Image { get; }
        public string Text { get; }

        public ChipDataObject(string text) {
            Text = text;
            Image = ImageSource.FromFile("smile");
        }
    }

    public class ChipViewModel : NotificationObject {
        ColorViewModel selectedTextColor;
        ColorViewModel selectedBackgroundColor;
        ColorViewModel selectedIconColor;
        ColorViewModel selectedBorderColor;

        double cornerRadius;
        double borderWidth;

        bool allowCustomCornerRadius;
        bool allowCustomTextColor;
        bool allowCustomBackgroundColor;
        bool shouldShowIcon;
        bool shouldShowBorder;
        bool removeIconVisible;

        public IList<ColorViewModel> Colors { get; }
        public IList<ChipDataObject> Items { get; }

        public ColorViewModel SelectedTextColor { get => selectedTextColor; set => SetProperty(ref selectedTextColor, value, UpdateTextColor); }
        public ColorViewModel SelectedBackgroundColor { get => selectedBackgroundColor; set => SetProperty(ref selectedBackgroundColor, value, UpdateBackgroundColor); }
        public ColorViewModel SelectedIconColor { get => selectedIconColor; set => SetProperty(ref selectedIconColor, value); }
        public ColorViewModel SelectedBorderColor { get => selectedBorderColor; set => SetProperty(ref selectedBorderColor, value, UpdateBorder); }

        public bool AllowCustomCornerRadius { get => allowCustomCornerRadius; set => SetProperty(ref allowCustomCornerRadius, value, UpdateCornerRadius); }
        public bool AllowCustomTextColor { get => allowCustomTextColor; set => SetProperty(ref allowCustomTextColor, value, UpdateTextColor); }
        public bool AllowCustomBackgroundColor { get => allowCustomBackgroundColor; set => SetProperty(ref allowCustomBackgroundColor, value, UpdateBackgroundColor); }
        public bool ShouldShowIcon { get => shouldShowIcon; set => SetProperty(ref shouldShowIcon, value); }
        public bool ShouldShowBorder { get => shouldShowBorder; set => SetProperty(ref shouldShowBorder, value, UpdateBorder); }

        public double CornerRadius { get => cornerRadius; set => SetProperty(ref cornerRadius, value, UpdateCornerRadius); }
        public double BorderWidth { get => borderWidth; set => SetProperty(ref borderWidth, value, UpdateBorder); }
        public bool RemoveIconVisible { get => removeIconVisible; set => SetProperty(ref removeIconVisible, value); }

        CustomChipGroup ChipGroup { get; }
        CornerRadius DefaultCornerRadius { get; }
        Color DefaultTextColor { get; }
        Color DefaultBackgroundColor { get; }
        Color DefaultIconColor { get; }
        Color DefaultBorderColor { get; }
        double DefaultBorderThickness { get; }

        public ChipViewModel(CustomChipGroup chipGroup) {
            ChipGroup = chipGroup;
            DefaultCornerRadius = chipGroup.ActualAppearance.ChipCornerRadius;
            DefaultBorderThickness = chipGroup.ActualAppearance.ChipBorderThickness;
            DefaultTextColor = chipGroup.ActualAppearance.ChipTextColor;
            DefaultBackgroundColor = chipGroup.ActualAppearance.ChipBackgroundColor;
            DefaultIconColor = chipGroup.ActualAppearance.ChipIconColor;
            DefaultBorderColor = chipGroup.ActualAppearance.ChipBorderColor;
            Colors = ColorViewModel.CreateDefaultColors();
            Items = new List<ChipDataObject>() {
                new ChipDataObject("Chip 1"),
                new ChipDataObject("Chip 2"),
                new ChipDataObject("Chip 3"),
                new ChipDataObject("Chip 4"),
                new ChipDataObject("Chip 5"),
                new ChipDataObject("Chip 6")
            };
            SelectedTextColor = Colors[6];
            SelectedBackgroundColor = Colors[4];
            SelectedIconColor = Colors[0];
            SelectedBorderColor = Colors[1];
            UpdateCornerRadius();
            UpdateTextColor();
            UpdateBackgroundColor();
            UpdateBorder();
        }

        void UpdateCornerRadius() {
            ChipGroup.ChipCornerRadius = AllowCustomCornerRadius ? CornerRadius : DefaultCornerRadius;
        }
        void UpdateTextColor() {
            ChipGroup.ChipTextColor = AllowCustomTextColor ? SelectedTextColor.Color : DefaultTextColor;
        }
        void UpdateBackgroundColor() {
            ChipGroup.ChipBackgroundColor = AllowCustomBackgroundColor ? SelectedBackgroundColor.Color : DefaultBackgroundColor;
        }
        void UpdateBorder() {
            ChipGroup.ChipBorderColor = ShouldShowBorder ? SelectedBorderColor.Color : DefaultBorderColor;
            ChipGroup.ChipBorderThickness = ShouldShowBorder ? BorderWidth : DefaultBorderThickness;
        }
    }
}
