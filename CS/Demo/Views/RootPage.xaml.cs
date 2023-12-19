using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui {
    public partial class AppShell : Shell {
        public AppShell() {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
