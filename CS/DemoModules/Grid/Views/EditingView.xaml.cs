using System;
using System.Globalization;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.Styles.ThemeLoader;
using DevExpress.Maui.Core;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class EditingView : BaseGridContentPage {
        public EditingView() {
            InitializeComponent();
        }
        protected override object LoadData() {
            return new OutlookDataRepository(300);
        }

        void DataGridView_ValidationError(object sender, ValidationErrorEventArgs e) {
            DisplayAlert("Validation Error", e.ErrorContent, "OK");
        }
        void DataGridView_ValidateCell(object sender, ValidateCellEventArgs e) {
            if (e.FieldName == "From.Name" && string.IsNullOrWhiteSpace((string)e.NewValue))
                e.ErrorContent = "The From field is required.";
            else if (e.FieldName == "Sent" && (DateTime)e.NewValue > DateTime.Now.Date)
                e.ErrorContent = "The Sent field cannot be in the future.";
        }
        async void DataGridView_ValidateAndSave(object sender, ValidateItemEventArgs e) {
            OutlookData item = e.Item as OutlookData;
            if (item == null)
                return;
            string errorText = string.Empty;
            if (string.IsNullOrWhiteSpace(item.From.Name))
                errorText = "The From field is required.";
            if (item.Sent > DateTime.Now.Date) {
                errorText += "\nThe Sent field cannot be in the future.";
            }

            errorText.TrimStart('\n');
            e.IsValid = string.IsNullOrWhiteSpace(errorText);
            if(!e.IsValid)
                await DisplayAlert("Error", errorText, "OK");
        }

         void Handle_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item == null || dataGridView.EditorShowMode == EditorShowMode.Tap)
                return;
            this.dataGridView.ShowDetailEditForm(e.RowHandle);
            
            
        }

        async void OnItemClicked(object sender, EventArgs e) {
            if (!dataGridView.CloseEditor(true)) {
                dataGridView.CloseEditor(false);
            }
            string action = await DisplayActionSheet("Edit Mode", "Cancel", null, "Inplace", "Edit Form");
            if (action == "Cancel")
                return;
            dataGridView.EditorShowMode = action == "Inplace" ? EditorShowMode.Tap : EditorShowMode.Never;
        }

        void DateColumn_PickerDisableDate(System.Object sender, DisableDateEventArgs e) {
            if(e.Date.DayOfWeek == DayOfWeek.Sunday || e.Date.DayOfWeek == DayOfWeek.Saturday) {
                e.IsDisabled = true;
            }
        }
    }

    public class DoubleToProgressConverter : IValueConverter {
        public double MaxValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return (double)value / MaxValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
