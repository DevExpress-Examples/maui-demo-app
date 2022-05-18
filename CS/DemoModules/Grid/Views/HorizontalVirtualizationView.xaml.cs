using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class HorizontalVirtualizationView : BaseGridContentPage {
        readonly double columnWidth = DeviceInfo.Idiom == DeviceIdiom.Tablet ? 180 : 150;

        public HorizontalVirtualizationView() {
            AddResources();
            InitializeComponent();

            this.dataGridView.Columns.Add(new TextColumn() {
                FieldName = "Full Name",
                Width = columnWidth,
                FixedStyle = DeviceInfo.Idiom == DeviceIdiom.Tablet ? FixedStyle.Start : FixedStyle.None
            });
            for (int i = 0; i < 5; i++) {
                int year = DateTime.Now.Year - 5 + i;
                for (int j = 1; j < 5; j++) {
                    AddColumnAndSummary("Q" + j + ", " + year, this.columnWidth, "quaterColumnTemplate");
                }
                AddColumnAndSummary("" + year + " Total", this.columnWidth + 20, "yearTotalColumnTemplate");
            }
        }

        void AddResources() {
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                Resources.Add("FontSize", 14.0);
            } else {
                Resources.Add("FontSize", 12.0);
            }
        }

        void AddColumnAndSummary(string fieldName, double width, string templateName) {
            this.dataGridView.Columns.Add(new TemplateColumn() {
                FieldName = fieldName,
                Width = width,
                HorizontalContentAlignment = TextAlignment.End,
                DisplayTemplate = (DataTemplate)Resources[templateName]
            });
            this.dataGridView.TotalSummaries.Add(new GridColumnSummary() { FieldName = fieldName, Type = SummaryType.Sum, DisplayFormat = "SUM={0:C2}" });
        }

        protected override object LoadData() {
            return new EmployeeSales();
        }
    }
}
