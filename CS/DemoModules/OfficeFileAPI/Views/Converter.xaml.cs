using DemoCenter.Maui.DemoModules.OfficeFileAPI.ViewModels;

namespace DemoCenter.Maui.Views;

public partial class ConverterDemo : Demo.DemoPage {
    public ConverterDemo() {
        InitializeComponent();
        BindingContext = new ConverterViewModel();
    }
}

