using DemoCenter.Maui.Services;
using DemoCenter.Maui.Styles.ThemeLoader;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class WeekViewDemo : Demo.DemoPage {
        bool inNavigation = false;

        public WeekViewDemo() {
            InitializeComponent();
            BindingContext = new EmployeeCalendarViewModel();

            Color accentColor;
            Color todayBackgroundColor;
            if (ThemeLoader.IsLightTheme) {
                accentColor = Color.FromArgb("#6750a4");
                todayBackgroundColor = Color.FromArgb("#7FDFD8F7");
            } else {
                accentColor = Color.FromArgb("#D0BCff");
                todayBackgroundColor = Color.FromArgb("#4C524670");
            }
            Resources.Add("DayViewHeaderItem_TodayDayNumberBackgroundColor", accentColor);
            Resources.Add("DayViewHeaderItem_TodayWeekDayTextStyle_Color", accentColor);
            Resources.Add("DayCell_TodayBackgroundColor", todayBackgroundColor);
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            this.inNavigation = false;
        }

        async void WeekView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (this.inNavigation)
                return;
            Page appointmentPage = this.storage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                this.inNavigation = true;
                await NavigationService.NavigateToPage(appointmentPage);
            }
        }
    }
}
