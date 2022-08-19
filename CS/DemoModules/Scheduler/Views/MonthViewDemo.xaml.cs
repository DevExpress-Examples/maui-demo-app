using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Core.Themes;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.Views {
    public partial class MonthViewDemo : ContentPage {
        readonly EmployeeCalendarViewModel viewModel = new EmployeeCalendarViewModel();
        bool inNavigation = false;

        public MonthViewDemo() {
            InitializeComponent();
            BindingContext = viewModel;

            Color accentColor;
            Color todayBackgroundColor;
            if (ThemeManager.ThemeName == Theme.Light) {
                accentColor = Color.FromArgb("#5B27D9");
                todayBackgroundColor = Color.FromArgb("#7FDFD8F7");
            } else {
                accentColor = Color.FromArgb("#9D7DE8");
                todayBackgroundColor = Color.FromArgb("#4C524670");
            }
            Resources.Add("MonthViewHeaderItem_TodayWeekDayTextStyle_Color", accentColor);
            Resources.Add("MonthCell_TodayDayNumberBackgroundColor", accentColor);
            Resources.Add("SchedulerEditPageAccentColor", accentColor);
            Resources.Add("MonthCell_TodayBackgroundColor", todayBackgroundColor);
        }
        
        void MonthView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation || e.IntervalInfo == null)
                return;
            viewModel.Start = e.IntervalInfo.Start;
            inNavigation = true;
            NavigationService.NavigateToPage(new DayViewModule(viewModel, this.monthView.DataStorage));
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }
    }
}
