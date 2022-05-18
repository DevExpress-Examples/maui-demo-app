using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class CustomAppearanceView : BaseGridContentPage {
        public CustomAppearanceView() {
            Resources.Add("IsAverageMonthlySalesVisible", DeviceInfo.Idiom == DeviceIdiom.Tablet);
            InitializeComponent();
        }

        protected override object LoadData() {
            return SalesDataGenerator.CreateData();
        }

        void DataGridView_CustomCellStyle(object sender, CustomCellStyleEventArgs e) {
            if(e.RowHandle % 2 == 0)
                e.BackgroundColor = GetColorFromResource("GridCustomAppearanceOddRowBackgroundColor");
            e.FontColor = GetColorFromResource("GridCustomAppearanceFontColor");
            if(e.FieldName == "ActualSales" || e.FieldName == "TargetSales") {
                double value = (double)dataGridView.GetCellValue(e.RowHandle, e.FieldName);
                if(value > 7000000)
                    e.FontColor = GetColorFromResource("GridCustomAppearancePositiveFontColor");
                else if (value < 4000000)
                    e.FontColor = GetColorFromResource("GridCustomAppearanceNegativeFontColor");
            }
        }

        Color GetColorFromResource(string resourceName) {
            return (Color)Application.Current.Resources[resourceName];
        }
    }
}
