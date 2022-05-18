using System;
using Microsoft.Maui.ApplicationModel;

namespace DemoCenter.Maui.Services {
    public class MauiUriOpener : IOpenUriService {
        public void Open(string uri) {
            Launcher.OpenAsync(new Uri(uri));
        }
    }
}
