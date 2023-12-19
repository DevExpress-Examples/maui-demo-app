using System;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Core;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views;

public partial class ThemesPage : ContentPage {
    private ThemesViewModel viewModel;

    public ThemesPage() {
        viewModel = new ThemesViewModel();
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void Color_Changed(object sender, EventArgs e) {
        if (sender is not ChoiceChipGroup chipGroup || chipGroup.SelectedIndex < 0)
            return;
        var context = viewModel.Items[chipGroup.SelectedIndex];
        viewModel.ChangeColor(context);
    }

    private async void Apply_Clicked(object sender, EventArgs e) {
        if (viewModel.IsCustomSource) {
            ThemeManager.Theme = new Theme(viewModel.PreviewColor);
            viewModel.SelectedColorIndex = -1;
        }
        await Navigation.PopAsync();
    }
    private async void Cancel_Clicked(object sender, EventArgs e) {
        await Navigation.PopAsync();
    }
}

