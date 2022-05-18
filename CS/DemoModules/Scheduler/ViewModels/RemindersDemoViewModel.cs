using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DemoCenter.Maui.ViewModels {
    public class RemindersDemoViewModel {
        public RemindersDemoViewModel() {
            Appointments = new ObservableCollection<ReminderAppointment>(AppointmentRepository.Instance.GetItems());
            Appointments.CollectionChanged += OnAppointmentsCollectionChanged;
            foreach(ReminderAppointment appointment in Appointments)
                SubscribeAppointmentEvent(appointment);
        }

        void OnAppointmentsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.OldItems != null)
                foreach (ReminderAppointment obj in e.OldItems) {
                    UnSubscribeAppointmentEvent(obj);
                    AppointmentRepository.Instance.DeleteItem(obj.Id);
                }

            if (e.NewItems != null)
                foreach (ReminderAppointment obj in e.NewItems) {
                    SubscribeAppointmentEvent(obj);
                    AppointmentRepository.Instance.SaveItem(obj);
                }
        }

        public ObservableCollection<ReminderAppointment> Appointments { get; protected set; }

        void SubscribeAppointmentEvent(ReminderAppointment apt) {
            apt.PropertyChanged += OnAppointmentPropertyChanged;
        }
        void UnSubscribeAppointmentEvent(ReminderAppointment apt) {
            apt.PropertyChanged -= OnAppointmentPropertyChanged;
        }
        void OnAppointmentPropertyChanged(object sender, PropertyChangedEventArgs e) {
            AppointmentRepository.Instance.SaveItem(sender as ReminderAppointment);
        }
    }
}
