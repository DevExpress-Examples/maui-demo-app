using System;
using System.IO;
using System.Threading;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Storage;
using DevExpress.Maui.Controls;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Views;

public partial class ToolbarView : Demo.DemoPage {
    private ToolbarViewModel viewModel;

    public ToolbarView() {
        InitializeComponent();
        viewModel = new ToolbarViewModel(drawingView);
        BindingContext = viewModel;
        for (int i = 0; i < 32; i++) {
            int lineWidth = i + 1;
            ToolbarToggleButton button = new ToolbarToggleButton();
            button.Content = lineWidth;
            button.GroupName = "LineWidth";
            button.IsChecked = (lineWidth == drawingView.LineWidth);
            button.Clicked += (_, _) => viewModel.LineWidth = lineWidth;
            lineWidthSelectionPage.Items.Add(button);
        }
    }

    private void OnLineColorButtonClicked(object sender, EventArgs e) {
        viewModel.IsColorSelectorOpen = !viewModel.IsColorSelectorOpen;
    }
    private void OnClearAllButtonClicked(object sender, EventArgs e) {
        drawingView.Clear();
    }
    private async void OnExportButtonClicked(object sender, EventArgs e) {
        if (drawingView.Lines.Count > 0) {
            SolidColorBrush brush = new SolidColorBrush() { Color = Colors.White };
            using Stream stream = await DrawingView.GetImageStream(drawingView.Lines, drawingView.Bounds.Size, brush);
            await FileSaver.Default.SaveAsync("ToolbarDemo.bmp", stream, CancellationToken.None);
        }
    }
}
