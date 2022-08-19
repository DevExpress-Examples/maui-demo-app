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

        void OnSwitchToggled(System.Object sender, Microsoft.Maui.Controls.ToggledEventArgs e) {
            // HACK Workaround for https://github.com/dotnet/maui/issues/3410
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
