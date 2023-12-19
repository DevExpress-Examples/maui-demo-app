using DemoCenter.Maui.Demo;

namespace DemoCenter.Maui.Views;
public partial class ShimmerView : AdaptivePage {
    private ShimmerViewModel dataModel;

    public ShimmerView() {
        InitializeComponent();
        this.dataModel = new ShimmerViewModel();
        BindingContext = this.dataModel;
    }

    protected override async void OnAppearing() {
        base.OnAppearing();
        await this.dataModel.LoadDataAsync();
    }
}
