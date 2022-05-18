using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class LargeDataset : ContentPage {
        public LargeDataset() {
            
            InitializeComponent();
            BindingContext = new LargeDatasetViewModel(chart);
        }
    }
}
