using DevExpress.Maui.Editors;
using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class ChipView : Demo.DemoPage {
        public ChipView() {
            InitializeComponent();
            BindingContext = new ChipViewModel(this.chipGroup);
        }

        void OnChipTap(object sender, ChipEventArgs e) {
            e.Chip.IsSelected = !e.Chip.IsSelected;
        }

        void OnSwitchToggled(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e) {
            
#if __IOS__
            if (e.Value) {
                UIKit.UIView nativeGrid = this.chipsCornerRadiusContainer.Handler.PlatformView as UIKit.UIView;
                UIKit.UIView nativeGridParent = nativeGrid?.Superview;
                nativeGridParent?.Superview?.SetNeedsLayout();
            }
#endif
        }
    }
}
