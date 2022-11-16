using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo;

public class DemoPage : ContentPage {
    public DemoPage() {
        Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, false);
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        base.OnPropertyChanged(propertyName);
        if (propertyName == nameof(Content) && Content != null && !Content.IsSet(View.BackgroundColorProperty) && !Content.IsSet(View.BackgroundProperty))
            Content.SetDynamicResource(View.BackgroundColorProperty, "BackgroundThemeColor");
    }
}
