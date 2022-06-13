using System;
using System.Threading.Tasks;
using DemoCenter.Maui.Services;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Scheduler;
using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.Views {
    public partial class RemindersDemo : ContentPage {
        readonly Random rnd = new Random();
        readonly RemindersNotificationCenter remindersNotificationCenter = new RemindersNotificationCenter();
        readonly RemindersDemoViewModel viewModel = new RemindersDemoViewModel();
        bool inNavigation = false;

        public RemindersDemo() {
            InitializeComponent();
            BindingContext = viewModel;
        }

        public async void OpenAppointmentEditForm(Guid reminderId, int recurrenceIndex) {
            AppointmentItem appointment = storage.FindAppointmentByReminder(reminderId);
            if (appointment != null && recurrenceIndex >= 0)
                appointment = storage.GetOccurrenceOrException(appointment, recurrenceIndex);
            if (appointment != null)
                await OpenAppointmentEditForm(appointment);
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            inNavigation = false;
        }

        Task OpenAppointmentEditForm(Page appointmentPage) {
            inNavigation = true;
            return NavigationService.NavigateToPage(appointmentPage);
        }
        Task OpenAppointmentEditForm(AppointmentItem appointment) {
            return OpenAppointmentEditForm(new AppointmentDetailPage(appointment, storage, true));
        }

        void OnRemindersChanged(object sender, EventArgs e) {
            remindersNotificationCenter.UpdateNotifications(storage);
        }

        void OnClicked(object sender, EventArgs e) {
            AppointmentItem appointmentWithReminder = storage.CreateAppointmentItem();            
            DateTime start = DateTime.Now.AddSeconds(30);
            appointmentWithReminder.Start = start;
            appointmentWithReminder.End = start.AddHours(1);
            appointmentWithReminder.Subject = "Appointment with Reminder";
            appointmentWithReminder.LabelId = rnd.Next(0, storage.LabelItems.Count - 1);
            appointmentWithReminder.StatusId = rnd.Next(0, storage.StatusItems.Count - 1);
            appointmentWithReminder.Reminders.Add(new TimeSpan());
            storage.AppointmentItems.Add(appointmentWithReminder);
        }
        
        async void OnTap(object sender, SchedulerGestureEventArgs e) {
            if (inNavigation)
                return;
            Page appointmentPage = storage.CreateAppointmentPageOnTap(e, true);
            if (appointmentPage != null) {
                inNavigation = true;
                await NavigationService.NavigateToPage(appointmentPage);
            }
        }
    }
}
