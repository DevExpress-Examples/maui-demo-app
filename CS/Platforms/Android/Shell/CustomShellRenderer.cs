using AndroidX.DrawerLayout.Widget;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace DemoCenter.Maui;

public class CustomShellRenderer : ShellRenderer {
    protected override IShellToolbarTracker CreateTrackerForToolbar(AndroidX.AppCompat.Widget.Toolbar toolbar) {
        return new CustomShellToolbarTracker(this, toolbar, ((IShellContext)this).CurrentDrawerLayout);
    }

    sealed class CustomShellToolbarTracker : ShellToolbarTracker {
        public CustomShellToolbarTracker(IShellContext shellContext, AndroidX.AppCompat.Widget.Toolbar toolbar, DrawerLayout drawerLayout) : base(shellContext, toolbar, drawerLayout) {
        }
        protected override void OnPageChanged(Page oldPage, Page newPage) {
            base.OnPageChanged(oldPage, newPage);
            if (newPage is not null && Shell.GetNavBarHasShadow(newPage)) {
                Shell.SetNavBarHasShadow(newPage, false);
                Shell.SetNavBarHasShadow(newPage, true);
            }
        }
    }
}
