using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class LargeDataset : Demo.DemoPage {
        public LargeDataset() {
            InitializeComponent();
            BindingContext = new LargeDatasetViewModel(chart);
        }
    }
}
