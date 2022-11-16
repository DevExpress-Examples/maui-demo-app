using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.Views {
    public partial class GroupingView : BaseGridContentPage {
        public GroupingView() {
            InitializeComponent();
        }
        protected override object LoadData() {
            return new InvoicesRepository();
        }
    }
}
