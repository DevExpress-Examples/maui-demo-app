using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views;

public partial class RadialProgressBarReportView : ContentPage {
    static void OnOrientationChanged(RadialProgressBarReportView view) {
        if (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait || DeviceInfo.Idiom == DeviceIdiom.Tablet) {
            view.stackLayout.Orientation = StackOrientation.Vertical;
        } else {
            view.stackLayout.Orientation = StackOrientation.Horizontal;
        }
    }
    public TestReport[] Results { get; }
    public RadialProgressBarReportView(TestReport[] results) {
        Results = results;
        InitializeComponent();
        BindingContext = this;
        ON.OrientationChanged(this, OnOrientationChanged);
        OnOrientationChanged(this);
    }

    async void OnButtonTap(object sender, DXTapEventArgs e) {
        await Shell.Current.Navigation.PopAsync();
    }
}
