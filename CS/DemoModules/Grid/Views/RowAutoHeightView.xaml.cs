using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;

namespace DemoCenter.Maui.Views {
    public partial class RowAutoHeightView : BaseGridContentPage {
        public RowAutoHeightView() {
            InitializeComponent();   
        }

        protected override object LoadData() {
            return new MainGridViewModel(new GridOrdersRepository());
        }
    }
}
