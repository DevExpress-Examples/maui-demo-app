using DemoCenter.Maui.DemoModules.Grid.Data;

namespace DemoCenter.Maui.Views {
    public partial class LoadMoreView : BaseGridContentPage {
        public LoadMoreView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return new OutlookDataRepository();
        }
    }
}
