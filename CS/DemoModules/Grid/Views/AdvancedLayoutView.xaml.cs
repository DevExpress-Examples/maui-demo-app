using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.Views {
    public partial class AdvancedLayoutView : BaseGridContentPage {
        public AdvancedLayoutView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return new EmployeesRepository();
        }
    }
}
