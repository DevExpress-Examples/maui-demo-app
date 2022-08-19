using System;
using System.Globalization;
using DemoCenter.Maui.DemoModules.Grid.Data;
using DevExpress.Maui.Core.Themes;
using DemoCenter.Maui.Services;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class EditingView : BaseGridContentPage {
        public EditingView() {
            InitializeComponent();
            Color checkedCheckBoxColor;
            if (ThemeManager.ThemeName == Theme.Light) {
                checkedCheckBoxColor = Color.FromArgb("#5B27D9");
            } else {
                checkedCheckBoxColor = Color.FromArgb("#9D7DE8");
            }
            Resources.Add("GridCellCheckedCheckBoxColor", checkedCheckBoxColor);
        }

        protected override object LoadData() {
            return new OutlookDataRepository(300);
        }

        void DataGridView_ValidationError(object sender, ValidationErrorEventArgs e) {
            DisplayAlert("Validation Error", e.ErrorContent, "OK");
        }

        void DataGridView_ValidateCell(object sender, DataGridValidationEventArgs e) {
            if (e.FieldName == "From.Name" && string.IsNullOrWhiteSpace((string)e.NewValue))
                e.ErrorContent = "The From field is required.";
            if (e.FieldName == "Sent" && (DateTime)e.NewValue > DateTime.Now.Date)
                e.ErrorContent = "The Sent field cannot be in the future.";
        }

        void Handle_Tap(object sender, DataGridGestureEventArgs e) {
            if (e.Item == null || dataGridView.EditorShowMode == EditorShowMode.Tap)
                return;
            var editFormPage = new EditFormPage(dataGridView, dataGridView.GetItem(e.RowHandle));
            editFormPage.Disappearing += EditFormPage_Disappearing;
            editFormPage.ValidateCell += DataGridView_ValidateCell;
            NavigationService.NavigateToPage(editFormPage);
        }

        void EditFormPage_Disappearing(object sender, EventArgs e) {
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
