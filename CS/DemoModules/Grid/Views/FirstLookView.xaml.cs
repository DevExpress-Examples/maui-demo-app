using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class FirstLookView : BaseGridContentPage {
        public FirstLookView() {
            InitializeComponent();

#if PaidDemoModules
            ToolbarItems.Add(new ToolbarItem() {
                Text = "Export",
                IconImageSource = "export_button",
                Command = new Command(() => ExportButton_Clicked(null, null))
            });
            // TODO: Remove this line after Skia bug is fixed
            grid.Columns[0].AllowExport = false;
#endif
        }
        protected override object LoadData() {
            return new EmployeesRepository();
        }

        public void ExportButton_Clicked(object sender, EventArgs e) {
            this.bottomSheet.Show();
        }
    }
}