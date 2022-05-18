using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class CollectionViewHorizontalScrolling : ContentPage {
        public CollectionViewHorizontalScrolling() {
            InitializeComponent();
            BindingContext = new HorizontalScrollingModel();
        }
    }
}
