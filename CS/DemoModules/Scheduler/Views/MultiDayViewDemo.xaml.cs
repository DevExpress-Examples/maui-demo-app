using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class MultiDayViewDemo : Demo.DemoPage {
        bool inNavigation;

        public MultiDayViewDemo() {
            InitializeComponent();
            BindingContext = new EmployeeCalendarViewModel();
        }

        async void DayView_OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation)
                return;
            Page appointmentPage = storage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                inNavigation = true;
                await NavigationService.NavigateToPage(appointmentPage);
            }
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }
    }
}
