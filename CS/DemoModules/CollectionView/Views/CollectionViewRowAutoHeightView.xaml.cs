using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class CollectionViewRowAutoHeightView : ContentPage {
        public CollectionViewRowAutoHeightView() {
            InitializeComponent();
            BindingContext = new AutoHeightViewModel(new GridOrdersRepository());
        }
    }
}
