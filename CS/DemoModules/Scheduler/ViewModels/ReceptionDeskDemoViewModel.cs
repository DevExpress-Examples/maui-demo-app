using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DemoCenter.Maui.ViewModels {
    public class ReceptionDeskDemoViewModel: NotificationObject {
        readonly ReceptionDeskData data = new ReceptionDeskData();
        Doctor selectedDoctor;
        IReadOnlyList<MedicalAppointment> visibleAppointments = new List<MedicalAppointment>();

        public DateTime StartDate { get { return ReceptionDeskData.BaseDate; } }
        public IReadOnlyList<Doctor> Doctors { get { return data.Doctors; } }
        public Doctor SelectedDoctor {
            get { return selectedDoctor; }
            set {
                selectedDoctor = value;
                VisibleAppointments = data.MedicalAppointments.Where(a => {
                    return a.DoctorId.HasValue && selectedDoctor?.Id == a.DoctorId.Value;
                }).ToList();
                NotifyPropertyChanged();
            }
        }
        public IReadOnlyList<MedicalAppointment> VisibleAppointments {
            get => visibleAppointments;
            private set {
                visibleAppointments = value;
                NotifyPropertyChanged();
            }
        }
        public IReadOnlyList<MedicalAppointmentType> AppointmentTypes { get => data.Labels; }
        public IReadOnlyList<PaymentState> PaymentStates { get => data.Statuses; }

        public ReceptionDeskDemoViewModel() {
            SelectedDoctor = Doctors.FirstOrDefault();
        }

        void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
            OnPropertyChanged(propertyName);
        }
    }
}
