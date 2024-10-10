using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;

using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class DayViewModule : Demo.DemoPage {
        bool inNavigation;

        public DayViewModule(EmployeeCalendarViewModel viewModel, SchedulerDataStorage storage) {
            InitializeComponent();
            BindingContext = viewModel;
            this.dayView.DataStorage = storage;
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
