using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Demo;

public class DemoPage : ContentPage {
    public DemoPage() {
        Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, false);
    }
}
