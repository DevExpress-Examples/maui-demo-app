using Android.Content.Res;
using AndroidX.DrawerLayout.Widget;
using DevExpress.Maui.Core;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;

namespace DemoCenter.Maui;

public class CustomShellRenderer : ShellRenderer {
    protected override IShellToolbarTracker CreateTrackerForToolbar(AndroidX.AppCompat.Widget.Toolbar toolbar) {
        return new CustomShellToolbarTracker(this, toolbar, ((IShellContext)this).CurrentDrawerLayout);
    }
    protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker() {
        return new CustomToolbarAppearanceTracker();
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

    sealed class CustomToolbarAppearanceTracker : IShellToolbarAppearanceTracker {
        public void Dispose() { }

        public void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance) {
            var tintColor = ThemeManager.Theme.Scheme.OnSurface;
            if (toolbar == null)
                return;

            var menu = toolbar.Menu;
            if (menu == null || !menu.HasVisibleItems)
                return;

            for (int i = 0; i < menu.Size(); i++) {
                var nativeToolbarItem = menu.GetItem(i);
                nativeToolbarItem.SetIconTintList(ColorStateList.ValueOf(tintColor.ToPlatform()));
            }
        }

        public void ResetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker) { }
    }
}
