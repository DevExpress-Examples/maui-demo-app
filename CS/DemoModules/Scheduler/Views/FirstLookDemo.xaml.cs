using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookDemo : Demo.DemoPage {
        public FirstLookDemo() {
            InitializeComponent();
            BindingContext = new EmployeeCalendarViewModel();
        }
    }
}
