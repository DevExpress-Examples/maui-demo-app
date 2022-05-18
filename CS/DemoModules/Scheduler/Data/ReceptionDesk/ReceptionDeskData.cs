using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Maui.Scheduler.Internal;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace DemoCenter.Maui.ViewModels {
    public class Patient : DataItem {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
    }
    public class HospitalDepartment : DataItem {
        public string Name { get; set; }
        public ObservableCollection<Doctor> Doctors { get; } = new ObservableCollection<Doctor>();
    }
    public class Doctor : DataItem {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsVisible { get; set; }
    }
    public class MedicalAppointmentType : DataItem {
        public string Caption { get; set; }
        public Color Color { get; set; }
    }

    public class PaymentState : DataItem {
        public string Caption { get; set; }
        public Color Color { get; set; }
    }
    public class MedicalAppointment : DataItem {
        public bool AllDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? PatientId { get; set; }
        public string Note { get; set; }
        public string Subject { get; set; }
        public int PaymentStateId { get; set; }
        public int IssueId { get; set; }
        public int Type { get; set; }
        public string Location { get; set; }
        public string RecurrenceInfo { get; set; }
        public int? DoctorId { get; set; }
    }

    public class ReceptionDeskData {
        public static DateTime BaseDate = DateTime.Today;

        public static string[] AppointmentTypes = { "Hospital", "Office", "Phone Consultation", "Home", "Hospice" };

        public static string[] PaymentStates = { "Paid", "Unpaid" };
        public static Color[] PaymentStateColors = { Color.FromRgb(0xec, 0x70, 0x63), Color.FromRgb(0x45, 0xb3, 0x9d) };

        public static string[] PatientNames = { "Andrew Glover", "Mark Oliver", "Taylor Riley", "Addison Davis", "Benjamin Hughes", "Lucas Smith",
                                    "Robert King", "Laura Callahan", "Miguel Simmons", "Isabella Carter", "Andrew Fuller", "Madeleine Russell",
                                    "Steven Buchanan", "Nancy Davolio", "Michael Suyama", "Margaret Peacock", "Janet Leverling", "Ariana Alexander",
                                    "Brad Farkus", "Bart Arnaz", "Arnie Schwartz", "Billy Zimmer", "Samantha Piper", "Maggie Boxter",
                                    "Terry Bradley", "Greta Sims", "Cindy Stanwick", "Marcus Orbison",
                                    "Sandy Bright", "Ken Samuelson", "Brett Wade", "Wally Hobbs", "Brad Jameson", "Karen Goodson",
                                    "Morgan Kennedy", "Violet Bailey", "John Heart", "Arthur Miller", "Robert Reagan",
                                    "Ed Holmes", "Sammy Hill", "Olivia Peyton", "Jim Packard", "Hannah Brookly", "Harv Mudd",
                                    "Todd Hoffman", "Kevin Carter","Mary Stern", "Robin Cosworth","Jenny Hobbs", "Dallas Lou"};

        public static Dictionary<string, string[]> DepartmentCache = new Dictionary<string, string[]>();

        static Random rnd = new Random();
        
        static ReceptionDeskData() {
            DepartmentCache.Add("Therapy", new string[] { "Lincoln Bartlett", "Amelia Harper", "Stu Pizaro", "Sandra Johnson", "Victor Norris" });
            DepartmentCache.Add("Ophthalmology", new string[] { "Lucy Ball" });
            DepartmentCache.Add("Dentistry", new string[] { "Clark Morgan", "Leah Simpson" });
            DepartmentCache.Add("Surgery", new string[] { "Davey Jones" });
            DepartmentCache.Add("Neurology", new string[] { "Samantha Bright" });
        }
        static TimeSpan CalculateAppointmentDuration(Doctor resource, int density) {
            switch(resource.DepartmentId) {
                case 1:
                    return new TimeSpan(0, rnd.Next(2, 4) * 10, 0);
                case 2:
                    return new TimeSpan(0, rnd.Next(3, 6) * 10, 0);
                case 3:
                    return new TimeSpan(rnd.Next(0, 1), rnd.Next(3, 4) * 10, 0);
                case 4:
                    return new TimeSpan(rnd.Next(0, 1), rnd.Next(2, 5) * 10, 0);
                case 5:
                    return new TimeSpan(0, rnd.Next(2, 3) * 10, 0);
                default:
                    return new TimeSpan(0, rnd.Next(2, 3) * 10, 0);
            }
        }

        void CreatePatients() {
            ObservableCollection<Patient> result = new ObservableCollection<Patient>();
            int patientCount = PatientNames.Length;
            int patientId = 1;
            DateTime birthday = new DateTime(1975, 2, 5);
            for (int i = 0; i < patientCount; i++) {
                Patient patient = new Patient();
                patient.Id = patientId++;
                patient.Name = PatientNames[i];
                patient.BirthDate = birthday.AddMonths(rnd.Next(1, 12)).AddYears(rnd.Next(0, 20));
                patient.Phone = "(" + rnd.Next(100, 999) + ") " + rnd.Next(100, 999) + "-" + rnd.Next(1000, 9999);
                result.Add(patient);
            }
            Patients = result;
        }

        void CreateHospitalDepartments() {
            ObservableCollection<HospitalDepartment> departments = new ObservableCollection<HospitalDepartment>();
            int departmentId = 1;
            foreach (string name in DepartmentCache.Keys) {
                HospitalDepartment department = new HospitalDepartment();
                department.Id = departmentId++;
                department.Name = name;
                departments.Add(department);
            }
            HospitalDepartments = departments;
        }

        void CreateDoctors() {
            Dictionary<string, string[]> departmentCache = ReceptionDeskData.DepartmentCache;
            ObservableCollection<Doctor> allDoctors = new ObservableCollection<Doctor>();
            int medicId = 0;
            foreach (HospitalDepartment hospitalDepartment in HospitalDepartments) {
                ObservableCollection<Doctor> doctors = hospitalDepartment.Doctors;
                string[] medicNames = departmentCache[hospitalDepartment.Name];
                int medicCount = medicNames.Length;
                for (int i = 0; i < medicCount; i++) {
                    Doctor doctor = new Doctor();
                    doctor.Id = medicId++;
                    doctor.Name = medicNames[i];
                    doctor.Phone = "(" + rnd.Next(10, 99) + ") " + rnd.Next(100, 999) + "-" + rnd.Next(1000, 9999);
                    doctor.DepartmentId = hospitalDepartment.Id;
                    doctor.DepartmentName = hospitalDepartment.Name;
                    doctor.IsVisible = hospitalDepartment.Id == 1;
                    doctors.Add(doctor);
                    allDoctors.Add(doctor);
                }
            }
            Doctors = allDoctors;
        }

        void CreateMedicalAppointments(int aptDensity) {
            int appointmentId = 1;
            int patientIndex = 0;
            DateTime date = DateTimeHelper.GetStartOfWeek(BaseDate);
            ObservableCollection<MedicalAppointment> result = new ObservableCollection<MedicalAppointment>();
            foreach (Doctor doctor in Doctors) {
                TimeSpan duration = CalculateAppointmentDuration(doctor, aptDensity);
                DateTime firstDate = new DateTime(date.Year, date.Month, date.Day, rnd.Next(9, 11), 0, 0);
                DateTime finishDate = firstDate.AddDays(30);
                firstDate = firstDate.AddDays(-30);
                for (DateTime startDate = firstDate; startDate < finishDate; startDate += TimeSpan.FromDays(1)) {
                    TimeSpan endTime = new TimeSpan(18, 0, 0);
                    endTime = endTime.Add(-duration);
                    DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, endTime.Hours, endTime.Minutes, 0);
                    int room = rnd.Next(1, 100);
                    for (DateTime startTime = startDate; startTime < endDate; startTime += duration.Add(new TimeSpan(0, rnd.Next(2, 4) * aptDensity * 10, 0))) {
                        result.Add(CreateMedicAppointment(appointmentId, doctor, Patients[patientIndex], startTime, duration, room));
                        appointmentId++;
                        patientIndex++;
                        if (patientIndex >= Patients.Count - 1)
                            patientIndex = 1;
                    }
                }
            }
            MedicalAppointments = result;
        }

        void CreateLabels() {
            ObservableCollection<MedicalAppointmentType> result = new ObservableCollection<MedicalAppointmentType>();
            int count = AppointmentTypes.Length;
            for(int i = 0; i < count; i++) {
                MedicalAppointmentType appointmentType = new MedicalAppointmentType();
                appointmentType.Id = i;
                appointmentType.Caption = AppointmentTypes[i];
                result.Add(appointmentType);
            }
            Labels = result;
        }

        void CreateStatuses() {
            ObservableCollection<PaymentState> result = new ObservableCollection<PaymentState>();
            int count = PaymentStates.Length;
            for(int i = 0; i < count; i++) {
                PaymentState paymentState = new PaymentState();
                paymentState.Id = i;
                paymentState.Color = PaymentStateColors[i];
                paymentState.Caption = PaymentStates[i];
                result.Add(paymentState);
            }
            Statuses = result;
        }
        MedicalAppointment CreateMedicAppointment(int appointmentId, Doctor doctor, Patient patient, DateTime start, TimeSpan duration, int room) {
            MedicalAppointment medicalAppointment = new MedicalAppointment();
            medicalAppointment.Id = appointmentId;
            medicalAppointment.StartTime = start;
            medicalAppointment.EndTime = start.Add(duration);
            medicalAppointment.IssueId = Labels[rnd.Next(0, 5)].Id;
            medicalAppointment.PaymentStateId = Statuses[rnd.Next(0, 2)].Id;
            medicalAppointment.Subject = patient.Name;
            medicalAppointment.PatientId = patient.Id;
            medicalAppointment.DoctorId = doctor.Id;
            if (medicalAppointment.IssueId != 3)
                medicalAppointment.Location = String.Format("{0}", room);
            return medicalAppointment;
        }

        public ObservableCollection<Doctor> Doctors { get; private set; }
        public ObservableCollection<MedicalAppointment> MedicalAppointments { get; private set; }
        public ObservableCollection<HospitalDepartment> HospitalDepartments { get; private set; } 
        public ObservableCollection<Patient> Patients { get; private set; }
        public ObservableCollection<PaymentState> Statuses { get; private set; }
        public ObservableCollection<MedicalAppointmentType> Labels { get; private set; }

        public ReceptionDeskData(int aptDensity = 1) {
            CreatePatients();
            CreateHospitalDepartments();
            CreateStatuses();
            CreateLabels();
            CreateDoctors();
            CreateMedicalAppointments(aptDensity);
        }
    }
}
