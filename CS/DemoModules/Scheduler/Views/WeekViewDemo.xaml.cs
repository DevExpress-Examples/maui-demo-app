using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class WeekViewDemo : ContentPage {
        bool inNavigation = false;

        public WeekViewDemo() {
            InitializeComponent();
            BindingContext = new EmployeeCalendarViewModel();
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
                await Navigation.PushAsync(appointmentPage);
            }
        }
    }
}
