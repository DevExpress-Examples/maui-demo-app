using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using DevExpress.Maui.Core;

namespace DemoCenter.Maui.Views {
    public partial class CustomAppearanceView : BaseGridContentPage {
        public CustomAppearanceView() {
            InitializeComponent();
        }

        protected override object LoadData() {
            return SalesDataGenerator.CreateData();
        }

        void DataGridView_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e) {
            if (e.RowHandle % 2 == 0) {
                e.BackgroundColor = ThemeManager.Theme.Scheme.SurfaceContainerLowest;
                e.FontColor = ThemeManager.Theme.Scheme.OnSurfaceVariant;
            }
            if (e.FieldName == "ActualSales" || e.FieldName == "TargetSales") {
                double value = (double)dataGridView.GetCellValue(e.RowHandle, e.FieldName);
                if (value > 7000000)
                    e.FontColor = GetColorFromResource("GridCustomAppearancePositiveFontColor");
                else if (value < 4000000)
                    e.FontColor = GetColorFromResource("GridCustomAppearanceNegativeFontColor");
            }
        }

        Color GetColorFromResource(string resourceName) {
            foreach (var rd in Application.Current.Resources.MergedDictionaries)
                if (rd.TryGetValue(resourceName, out object color))
                    return (Color)color;

            return null;
        }
    }
}
