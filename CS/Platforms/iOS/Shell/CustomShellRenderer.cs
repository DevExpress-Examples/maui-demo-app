using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace DemoCenter.Maui;

public class CustomShellRenderer : ShellRenderer {
    protected override IShellPageRendererTracker CreatePageRendererTracker() {
        return new CustomShellPageRendererTracker(this);
    }
}