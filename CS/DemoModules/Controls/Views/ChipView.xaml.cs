using DevExpress.Maui.Editors;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class ChipView : Demo.DemoPage {
        public ChipView() {
            InitializeComponent();
            BindingContext = new ChipViewModel(this.chipGroup);
        }

        void OnChipTap(object sender, ChipEventArgs e) {
            e.Chip.IsSelected = !e.Chip.IsSelected;
        }
    }
}
