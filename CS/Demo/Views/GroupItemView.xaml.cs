using System;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class GroupItemView : Grid {
        public event EventHandler TappedControlShortcut;

        public GroupItemView() {
            InitializeComponent();
        }
        void GroupItemViewClicked(System.Object sender, System.EventArgs e) {
            TappedControlShortcut.Invoke(sender, e);
        }
    }
}
