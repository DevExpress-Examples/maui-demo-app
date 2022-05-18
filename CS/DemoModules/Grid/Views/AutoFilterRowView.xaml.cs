using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.DataGrid;

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
