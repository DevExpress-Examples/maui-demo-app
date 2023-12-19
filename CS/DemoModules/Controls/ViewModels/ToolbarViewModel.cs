using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

namespace DemoCenter.Maui.ViewModels;

public class ToolbarViewModel : NotificationObject {
    private DrawingView drawingView;
    private ObservableCollection<IDrawingLine> lines;
    private bool isPaintMode;
    private bool isColorSelectorOpen;
    private Color lineColor;
    private float lineWidth;

    public ToolbarViewModel(DrawingView drawingView) {
        this.drawingView = drawingView;
        lines = new ObservableCollection<IDrawingLine>();
        isPaintMode = true;
        lineColor = Color.FromArgb("#F9A825");
        lineWidth = 5;
    }
    public ObservableCollection<IDrawingLine> Lines {
        get => lines;
    }
    public bool IsPaintMode {
        get => isPaintMode;
        set {
            SetProperty(ref isPaintMode, value);
            OnPropertyChanged(nameof(ActualLineColor));
        }
    }
    public bool IsColorSelectorOpen {
        get => isColorSelectorOpen;
        set {
            SetProperty(ref isColorSelectorOpen, value);
        }
    }
    public Color LineColor {
        get => lineColor;
        set {
            SetProperty(ref lineColor, value);
            OnPropertyChanged(nameof(ActualLineColor));
        }
    }
    public Color ActualLineColor {
        get => isPaintMode ? lineColor : Colors.White;
    }
    public float LineWidth {
        get => lineWidth;
        set {
            SetProperty(ref lineWidth, value);
        }
    }
}
