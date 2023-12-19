using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class CollectionViewHorizontalScrolling : Demo.DemoPage {
        public CollectionViewHorizontalScrolling() {
            InitializeComponent();
            BindingContext = new HorizontalScrollingModel();
        }
    }
}
