using System;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Devices;
using DemoCenter.Maui.Demo;

namespace DemoCenter.Maui.Views {
    public partial class CalendarView : AdaptivePage {
        public CalendarView() {
            AddResources();
            InitializeComponent();
            ViewModel = new CalendarViewModel();
            BindingContext = ViewModel;
            OrientationChanged += OnOrientationChanged;
        }

        void AddResources() {
            Resources.Add("ListItemTextSize", DeviceInfo.Idiom == DeviceIdiom.Tablet ? 24.0 : 16.0);
            Resources.Add("ListHeaderTextSize", DeviceInfo.Idiom == DeviceIdiom.Tablet ? 30.0 : 20.0);
            Resources.Add("CalendarCellHeight", DeviceInfo.Platform == DevicePlatform.Android ? 36.0 : 46.0);
        }

        CalendarViewModel ViewModel { get; }

        void CustomDayCellStyle(object sender, CustomSelectableCellAppearanceEventArgs e) {
            if (e.Date == DateTime.Today)
                return;

            if (ViewModel.SelectedDate != null && e.Date == ViewModel.SelectedDate.Value)
                return;

            if (e.IsTrailing)
                return;

            SpecialDate specialDate = ViewModel.TryFindSpecialDate(e.Date);
            if (specialDate == null)
                return;

            e.FontAttributes = FontAttributes.Bold;
            Color textColor;
            if (specialDate.IsHoliday) {
                textColor = (Color)Application.Current.Resources["CalendarSpecialDatesHolidayTextColor"];
                e.EllipseBackgroundColor = (Color)Application.Current.Resources["CalendarSpecialDatesHolidayBackgroundColor"];
                e.TextColor = textColor;

                return;
            }
            textColor = (Color)Application.Current.Resources["CalendarSpecialDatesTextColor"];
            e.EllipseBackgroundColor = (Color)Application.Current.Resources["CalendarSpecialDatesBackgroundColor"];
            e.TextColor = textColor;
        }

        void OnOrientationChanged(object sender, EventArgs e) {
            DockLayout.SetDock(calendar, (Orientation == PageOrientation.Portrait) ? Dock.Top : Dock.Left);
            ViewModel.IsHolidaysAndObservancesListVisible = false;
            ViewModel.IsHolidaysAndObservancesListVisible = true;
        }
    }
}
