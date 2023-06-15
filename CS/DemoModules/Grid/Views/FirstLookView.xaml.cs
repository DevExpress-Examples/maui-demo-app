using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.DemoModules.Grid.ViewModels;
using DevExpress.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookView : BaseGridContentPage {
        public FirstLookView() {
            InitializeComponent();
        }
        protected override object LoadData() {
            return new EmployeesRepository();
        }

        public void ExportButton_Clicked(object sender, EventArgs e) {
            this.bottomSheet.Show();
        }
    }
}