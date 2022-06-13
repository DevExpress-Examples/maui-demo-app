using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Core.Themes;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class DayViewModule : ContentPage {
        bool inNavigation = false;

        public DayViewModule(EmployeeCalendarViewModel viewModel, SchedulerDataStorage storage) {
            InitializeComponent();
            BindingContext = viewModel;
            this.dayView.DataStorage = storage;
            Color accentColor;
            Color todayBackgroundColor;
            if (ThemeManager.ThemeName == Theme.Light) {
                accentColor = Color.FromArgb("#5B27D9");
                todayBackgroundColor = Color.FromArgb("#7FDFD8F7");
            } else {
                accentColor = Color.FromArgb("#9D7DE8");
                todayBackgroundColor = Color.FromArgb("#4C524670");
            }
            Resources.Add("DayViewHeaderItem_TodayDayNumberBackgroundColor", accentColor);
            Resources.Add("DayViewHeaderItem_TodayWeekDayTextStyle_Color", accentColor);
            Resources.Add("DayCell_TodayBackgroundColor", todayBackgroundColor);
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }

        async void DayView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation)
                return;
            Page appointmentPage = dayView.DataStorage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                inNavigation = true;
                await NavigationService.NavigateToPage(appointmentPage);
            }
        }
    }
}
