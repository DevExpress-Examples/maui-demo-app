using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.Styles.ThemeLoader;
using DemoCenter.Maui.ViewModels;

using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class DayViewDemo : Demo.DemoPage {
        readonly DailyEmployeeCalendarViewModel viewModel = new DailyEmployeeCalendarViewModel();
        bool inNavigation = false;

        public DayViewDemo() {
            InitializeComponent();
            BindingContext = this.viewModel;
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

        async void DayView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (this.inNavigation)
                return;
            Page appointmentPage = storage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                inNavigation = true;
                await NavigationService.NavigateToPage(appointmentPage);
            }
        }
        async void OnItemClicked(object sender, EventArgs e) {
            Dictionary<string, int> daysCountKeyValues = new Dictionary<string, int>() {
                { "One day",    1 },
                { "Three days", 3 },
                { "Five days",  5 },
            };
            string action = await DisplayActionSheet("Day Count", "Cancel", null, daysCountKeyValues.Keys.ElementAt(0), daysCountKeyValues.Keys.ElementAt(1), daysCountKeyValues.Keys.ElementAt(2));
            if (!String.IsNullOrEmpty(action) && daysCountKeyValues.ContainsKey(action))
                this.viewModel.DaysCount = daysCountKeyValues[action];
        }
    }
}
