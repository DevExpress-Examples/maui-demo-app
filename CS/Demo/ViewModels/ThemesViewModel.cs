using System.Collections.Generic;
using DevExpress.Maui.Core;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels;

public class ThemesViewModel : BaseViewModel {
    public List<ColorModel> Items { get; set; }
    public bool IsCustomSource { get; set; }

    private bool isEnabled = true;
    public bool IsEnabled {
        get => isEnabled;
        set => SetProperty(ref isEnabled, value);
    }

    private double red;
    public double Red {
        get => red;
        set => SetProperty(ref red, value, onChanged: (o, n) => UpdatePreviewColor(Red, Green, Blue));
    }

    private double green;
    public double Green {
        get => green;
        set => SetProperty(ref green, value, onChanged: (o, n) => UpdatePreviewColor(Red, Green, Blue));
    }

    private double blue;
    public double Blue {
        get => blue;
        set => SetProperty(ref blue, value, onChanged: (o, n) => UpdatePreviewColor(Red, Green, Blue));
    }

    private Color previewColor;
    public Color PreviewColor {
        get => previewColor;
        set => SetProperty(ref previewColor, value);
    }

    private string previewColorHex;
    public string PreviewColorHex {
        get => previewColorHex;
        set => SetProperty(ref previewColorHex, value);
    }

    private string previewColorName;
    public string PreviewColorName {
        get => previewColorName;
        set => SetProperty(ref previewColorName, value);
    }

    private bool isLightTheme;
    public bool IsLightTheme {
        get => isLightTheme;
        set {
            if (isLightTheme != value && value) {
                isLightTheme = true;
                isDarkTheme = false;
                isSystemTheme = false;
                OnPropertyChanged(nameof(IsDarkTheme));
                OnPropertyChanged(nameof(IsSystemTheme));
                UpdateTheme();
            } else {
                OnPropertyChanged(nameof(IsLightTheme));
            }
        }
    }

    private bool isDarkTheme;
    public bool IsDarkTheme {
        get => isDarkTheme;
        set {
            if (isDarkTheme != value && value) {
                isDarkTheme = true;
                isLightTheme = false;
                isSystemTheme = false;
                OnPropertyChanged(nameof(IsLightTheme));
                OnPropertyChanged(nameof(IsSystemTheme));
                UpdateTheme();
            } else {
                OnPropertyChanged(nameof(IsDarkTheme));
            }
        }
    }

    private bool isSystemTheme = true;
    public bool IsSystemTheme {
        get => isSystemTheme;
        set {
            if (isSystemTheme != value && value) {
                isSystemTheme = true;
                isDarkTheme = false;
                isLightTheme = false;
                OnPropertyChanged(nameof(IsDarkTheme));
                OnPropertyChanged(nameof(IsLightTheme));
                UpdateTheme();
            } else {
                OnPropertyChanged(nameof(IsSystemTheme));
            }
        }
    }

#if ANDROID
    private int selectedColorIndex = 1;
#else
    private int selectedColorIndex;
#endif
    public int SelectedColorIndex {
        get => selectedColorIndex;
        set => SetProperty(ref selectedColorIndex, value);
    }

    public ThemesViewModel() {
        Items = new List<ColorModel>() {
#if ANDROID
            new ColorModel(Colors.Black, "System Color", true),
#endif
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.Purple), ThemeSeedColor.Purple.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.Violet), ThemeSeedColor.Violet.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.Red), ThemeSeedColor.Red.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.Brown), ThemeSeedColor.Brown.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.TealGreen), ThemeSeedColor.TealGreen.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.Green), ThemeSeedColor.Green.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.DarkGreen), ThemeSeedColor.DarkGreen.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.DarkCyan), ThemeSeedColor.DarkCyan.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.DeepSeaBlue), ThemeSeedColor.DeepSeaBlue.ToString()),
            new ColorModel(ThemeManager.GetSeedColor(ThemeSeedColor.Blue), ThemeSeedColor.Blue.ToString()),
        };
    }

    public void ChangeColor(ColorModel colorModel) {
        if (colorModel == null)
            return;

        Red = colorModel.Color.Red;
        Green = colorModel.Color.Green;
        Blue = colorModel.Color.Blue;
        PreviewColorName = colorModel.DisplayName;
        IsEnabled = !colorModel.IsSystemColor;
        IsCustomSource = false;
        if (colorModel.IsSystemColor) {
            ThemeManager.UseAndroidSystemColor = true;
            return;
        }

        ThemeManager.UseAndroidSystemColor = false;
        ThemeManager.Theme = new Theme(colorModel.Color);
    }

    private void UpdatePreviewColor(double red, double green, double blue) {
        PreviewColor = Color.FromRgb(red, green, blue);
        PreviewColorHex = PreviewColor.ToHex();
        IsCustomSource = true;
    }
    private void UpdateTheme() {
        Application.Current.UserAppTheme = IsSystemTheme
            ? AppTheme.Unspecified
            : IsLightTheme ? AppTheme.Light : AppTheme.Dark;
    }
}

public class ColorModel {
    public Color Color { get; set; }
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public bool IsSystemColor { get; set; }

    public ColorModel(Color color, string displayName, bool isSystemColor = false) {
        Color = color;
        DisplayName = displayName;
        IsSystemColor = isSystemColor;
        Name = isSystemColor ? "System" : string.Empty;
    }
}