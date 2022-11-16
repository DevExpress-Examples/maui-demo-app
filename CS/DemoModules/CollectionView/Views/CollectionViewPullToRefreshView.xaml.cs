using DemoCenter.Maui.DemoModules.Drawer.Data;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.CollectionView.Views {
    public partial class CollectionViewPullToRefreshView : Demo.DemoPage {
        public CollectionViewPullToRefreshView() {
            InitializeComponent();
            BindingContext = new PullToRefreshViewModel(new MailMessagesRepository());
        }
    }
}
