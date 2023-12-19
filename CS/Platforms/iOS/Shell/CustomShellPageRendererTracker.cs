using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace DemoCenter.Maui;

public class CustomShellPageRendererTracker : ShellPageRendererTracker {
    public CustomShellPageRendererTracker(IShellContext shellContext) : base(shellContext) {
        Context = shellContext;
    }

    public IShellContext Context { get; }

    protected override void UpdateTitleView() {
        if (ViewController?.NavigationItem is null) {
            return;
        }
        var titleView = Shell.GetTitleView(Page);
        if (titleView == null) {
            var view = ViewController.NavigationItem.TitleView;
            ViewController.NavigationItem.TitleView = null;
            view?.Dispose();
        } else {
            ViewController.NavigationItem.TitleView = new CustomTitleViewContainer(titleView);
        }
    }
}