using System;
using DemoCenter.Maui.Demo;
using DevExpress.Maui.Core;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace DemoCenter.Maui.Views {
    public partial class HtmlEditView : Demo.AdaptivePage {
        public HtmlEditView() {
            InitializeComponent();
            this.edit.Focused += OnFocused;
            this.edit.Unfocused += OnUnfocused;
            UndoItem = new ToolbarItem() {
                IconImageSource = "dxre_undo.png",
                Command = this.edit.Commands.Undo
            };
            RedoItem = new ToolbarItem() {
                IconImageSource = "dxre_redo.png",
                Command = this.edit.Commands.Redo
            };
        }

        ToolbarItem UndoItem { get; }
        ToolbarItem RedoItem { get; }
        bool IsPageDisappearing { get; set; }

        protected override void OnAppearing() {
            IsPageDisappearing = false;
            base.OnAppearing();
#if IOS
            Microsoft.Maui.Platform.KeyboardAutoManagerScroll.Disconnect();
#endif
        }

        protected override void OnDisappearing() {
            IsPageDisappearing = true;
            base.OnDisappearing();
            Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific.Application.SetWindowSoftInputModeAdjust(this.Window, WindowSoftInputModeAdjust.Unspecified);
#if IOS
            Microsoft.Maui.Platform.KeyboardAutoManagerScroll.Connect();
#endif
        }

        protected override bool OnBackButtonPressed() {
            if (this.root.IsOpened) {
                this.root.IsOpened = false;
                return true;
            }
            return base.OnBackButtonPressed();
        }

        void OnFocused(object sender, EventArgs e) {
            this.AbortAnimation("mailPane");
            Animation animation = new Animation();
            animation.Add(0, 1, new Animation(v => this.mailAddress.Margin = new Thickness(0, -this.mailAddress.Height * v, 0, 0)));
            animation.Commit(this, "mailPane", 16, 400, Easing.CubicInOut, (v, c) => {
                if (c)
                    return;
                ToolbarItems.Remove(UndoItem);
                ToolbarItems.Remove(RedoItem);
                ToolbarItems.Insert(0, RedoItem);
                ToolbarItems.Insert(0, UndoItem);
                ((IShellController)Shell.Current).AppearanceChanged(this, false);
                this.mailAddress.IsVisible = false;
            });
        }

        void OnUnfocused(object sender, EventArgs e) {
            if (root.IsOpened || IsPageDisappearing)
                return;
            this.AbortAnimation("mailPane");
            this.mailAddress.IsVisible = true;
            Animation animation = new Animation(v => this.mailAddress.Margin = new Thickness(0, -this.mailAddress.Height * (1 - v), 0, 0));
            animation.Commit(this, "mailPane", 16, 250, Easing.CubicInOut, (v, c) => {
                if (c)
                    return;
                ToolbarItems.Remove(UndoItem);
                ToolbarItems.Remove(RedoItem);
            });
        }

        void OnOrientationChanged(object sender, EventArgs e) {
            this.root.FitKeyboardAreaToContent = Orientation == PageOrientation.Portrait ? KeyboardAreaSizeMode.SizeToContent : KeyboardAreaSizeMode.SizeToKeyboard;
        }
    }
}
