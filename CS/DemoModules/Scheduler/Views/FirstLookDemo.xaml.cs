using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookDemo : Demo.DemoPage {
        public FirstLookDemo() {
            InitializeComponent();
            BindingContext = new EmployeeCalendarViewModel();
        }
    }
}
