using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.Views {
    public partial class AutoFilterRowView : BaseGridContentPage {
        public AutoFilterRowView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return new OutlookDataRepository(300);
        }
    }
}
