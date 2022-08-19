using System;
using DemoCenter.Maui.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using DevExpress.Maui.Editors;
using Microsoft.Maui.Devices;

namespace DemoCenter.Maui.Views {
    public partial class CalendarView : ContentPage {
        public static readonly BindablePropertyKey OrientationPropertyKey = BindableProperty.CreateReadOnly("Orientation", typeof(StackOrientation), typeof(CalendarView), StackOrientation.Vertical);
        public static readonly BindableProperty OrientationProperty = OrientationPropertyKey.BindableProperty;
        public StackOrientation Orientation => (StackOrientation)GetValue(OrientationProperty);

        public CalendarView() {
            AddResources();
            InitializeComponent();
            ViewModel = new CalendarViewModel();
            BindingContext = ViewModel;
        }

        void AddResources() {
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet) {
                Resources.Add("ListItemTextSize", 24.0);
            } else {
                Resources.Add("ListItemTextSize", 16.0);
            }
        }

        CalendarViewModel ViewModel { get; }

        void CustomDayCellStyle(object sender, CustomSelectableCellStyleEventArgs e) {
            if (e.Date == DateTime.Today)
                return;

            if (ViewModel.SelectedDate != null && e.Date == ViewModel.SelectedDate.Value)
                return;

            SpecialDate specialDate = ViewModel.TryFindSpecialDate(e.Date);
            if (specialDate == null)
                return;

            e.FontAttributes = FontAttributes.Bold;
            Color textColor;
            if (specialDate.IsHoliday) {
                textColor = (Color)Application.Current.Resources["CalendarViewHolidayTextColor"];
                e.EllipseBackgroundColor = Color.FromRgba(textColor.Red, textColor.Green, textColor.Blue, 0.25);
                e.TextColor = textColor;

                return;
            }
            textColor = (Color)Application.Current.Resources["CalendarViewTextColor"];
            e.EllipseBackgroundColor = Color.FromRgba(textColor.Red, textColor.Green, textColor.Blue, 0.15);
            e.TextColor = textColor;
        }

        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);
            SetValue(OrientationPropertyKey, width > height ? StackOrientation.Horizontal : StackOrientation.Vertical);

            //temporary solution to refresh layout
            ViewModel.IsHolidaysAndObservancesListVisible = false;
            ViewModel.IsHolidaysAndObservancesListVisible = true;
        }
    }
}
