using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DemoCenter.Maui.ViewModels {
    public class EmployeeCalendarViewModel : NotificationObject {
        DateTime start;

        public EmployeeCalendarViewModel(DateTime startDate) {
            Start = startDate;
            Appointments = new ObservableCollection<TeamAppointment>(TeamData.AllAppointments);
        }
        public EmployeeCalendarViewModel() : this(TeamData.Start) {
        }

        public IEnumerable<TeamAppointment> Appointments { get; protected set; }
        public DateTime Start {
            get => this.start;
            set {
                this.start = value;
                NotifyPropertyChanged(nameof(Start));
            }
        }

        protected void NotifyPropertyChanged(string propertyName) {
            OnPropertyChanged(propertyName);
        }
    }
    public class DailyEmployeeCalendarViewModel : EmployeeCalendarViewModel {
        int daysCount = 1;

        public DailyEmployeeCalendarViewModel() : base(DateTime.Today) {
        }

        public int DaysCount {
            get => this.daysCount;
            set {
                this.daysCount = value;
                NotifyPropertyChanged(nameof(DaysCount));
            }
        }
    }
}
