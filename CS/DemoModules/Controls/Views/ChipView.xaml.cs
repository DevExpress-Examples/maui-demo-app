using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class ChipView : ContentPage {
        public ChipView() {
            InitializeComponent();
        }

        void OnChipTap(object sender, ChipEventArgs e) {
            e.Chip.IsSelected = !e.Chip.IsSelected;
        }
    }
}
