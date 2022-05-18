using System;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class GroupItemView : AbsoluteLayout {
        public event EventHandler TappedControlShortcut;

        public GroupItemView() {
            InitializeComponent();
        }
        void GroupItemViewTapped(object sender, EventArgs e) {
            TappedControlShortcut.Invoke(sender, e);
        }
    }
}
