using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookDemo : ContentPage {
        public FirstLookDemo() {
            InitializeComponent();
            BindingContext = new EmployeeCalendarViewModel();
        }
    }
}
