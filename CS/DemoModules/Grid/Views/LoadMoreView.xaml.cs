using DemoCenter.Maui.DemoModules.Grid.Data;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class LoadMoreView : BaseGridContentPage {
        public LoadMoreView() {
            Resources.Add("IsTablet", DeviceInfo.Idiom == DeviceIdiom.Tablet);
            InitializeComponent();
        }

        protected override object LoadData() {
            return new OutlookDataRepository();
        }
    }
}
