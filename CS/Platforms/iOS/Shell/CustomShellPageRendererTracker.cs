using CoreGraphics;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using UIKit;
using System;
using Microsoft.Maui.Graphics;
using System.Collections.Generic;

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
        var titleView = Shell.GetTitleView(Page) ?? Shell.GetTitleView(Context.Shell);
        if (titleView == null) {
            var view = ViewController.NavigationItem.TitleView;
            ViewController.NavigationItem.TitleView = null;
            view?.Dispose();
        } else {
            ViewController.NavigationItem.TitleView = new CustomTitleViewContainer(titleView);
        }
    }
}