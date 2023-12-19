using System;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.Core;
using DevExpress.Maui.DataGrid;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class HorizontalVirtualizationView : BaseGridContentPage {
        readonly double columnWidth = DeviceInfo.Idiom == DeviceIdiom.Tablet ? 180 : 150;

        public HorizontalVirtualizationView() {
            InitializeComponent();

            this.dataGridView.Columns.Add(new TextColumn() {
                FieldName = "Full Name",
                Width = 180,
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
        void AddColumnAndSummary(string fieldName, double width, string templateName) {
            this.dataGridView.Columns.Add(new TemplateColumn() {
                FieldName = fieldName,
                Width = width,
                HorizontalContentAlignment = TextAlignment.End,
                DisplayTemplate = (DataTemplate)Resources[templateName]
            });
            this.dataGridView.TotalSummaries.Add(new GridColumnSummary() {
                FieldName = fieldName, Type = DataSummaryType.Sum, DisplayFormat = "{0:C0}"
            });
        }

        protected override object LoadData() {
            return new EmployeeSales();
        }
    }
}
