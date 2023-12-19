using DemoCenter.Maui.DemoModules.OfficeFileAPI.ViewModels;
using Microsoft.Maui.Controls;
namespace DemoCenter.Maui.Views;

public partial class FillPDFMainPage : Demo.DemoPage {
    public FillPDFMainPage() {
        InitializeComponent();
    }

    private void NavigatedToPage(object sender, NavigatedToEventArgs args) {
        ((FillPDFMainPageViewModel)BindingContext).UpdatePreview();
    }
}

