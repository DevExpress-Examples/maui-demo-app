using System;
using System.Globalization;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class EditingView : BaseGridContentPage {
        public EditingView() {
            InitializeComponent();
        }

        private void DataGridView_ValidationError(object sender, ValidationErrorEventArgs e) {
            DisplayAlert("Validation Error", e.ErrorContent, "OK");
        }

        private void DataGridView_ValidateCell(object sender, DataGridValidationEventArgs e) {
            if (e.FieldName == "From.Name" && string.IsNullOrWhiteSpace((string)e.NewValue))
                e.ErrorContent = "The From field is required.";
            if (e.FieldName == "Sent" && (DateTime)e.NewValue > DateTime.Now.Date)
                e.ErrorContent = "The Sent field cannot be in the future.";
        }

        protected override object LoadData() {
            return new OutlookDataRepository(300);
        }

        void Handle_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item == null || dataGridView.EditorShowMode == EditorShowMode.Tap)
                return;
            var editFormPage = new EditFormPage(dataGridView, dataGridView.GetItem(e.RowHandle));
            editFormPage.Disappearing += EditFormPage_Disappearing;
            editFormPage.ValidateCell += DataGridView_ValidateCell;
            Navigation.PushAsync(editFormPage);
        }

        private void EditFormPage_Disappearing(object sender, EventArgs e) {
            var editFormPage = (EditFormPage)sender;
            editFormPage.Disappearing -= EditFormPage_Disappearing;
            editFormPage.ValidateCell -= DataGridView_ValidateCell;
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
