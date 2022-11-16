using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookView : BaseGridContentPage {
        public FirstLookView() {
            InitializeComponent();
        }
        protected override object LoadData() {
            return new EmployeesRepository();
        }
    }
}
