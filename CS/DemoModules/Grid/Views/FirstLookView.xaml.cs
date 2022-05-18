using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookView : BaseGridContentPage {
        public FirstLookView() {
            AddResources();
            InitializeComponent();
        }

        void AddResources() {
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                Resources.Add("FontSize", 14.0);
                Resources.Add("ColumnMinWidth", 200.0);
            } else {
                Resources.Add("FontSize", 12.0);
                Resources.Add("ColumnMinWidth", 120.0);
            }
        }

        protected override object LoadData() {
            return new EmployeesRepository();
        }
    }
}
