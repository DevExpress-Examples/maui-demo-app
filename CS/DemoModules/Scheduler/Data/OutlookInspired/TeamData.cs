using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Maui.Scheduler;

namespace DemoCenter.Maui.ViewModels {
    public class TeamCalendar : DataItem {
        string name;

        public string Name {
            get => name;
            set => SetProperty(ref name, value);
        }
    }

    public class TeamAppointment : DataItem {
        int appointmentType;
        bool allDay;
        DateTime start;
        DateTime end;
        string subject;
        string description;
        int status;
        int label;
        string location;
        int calendarId;
        string recurrenceInfo;
        string timeZoneId;

        public int AppointmentType {
            get => appointmentType;
            set => SetProperty(ref appointmentType, value);
        }
        public bool AllDay {
            get => allDay;
            set => SetProperty(ref allDay, value);
        }
        public DateTime Start {
            get => start;
            set => SetProperty(ref start, value);
        }
        public DateTime End {
            get => end;
            set => SetProperty(ref end, value);
        }

        public string Subject {
            get => subject;
            set => SetProperty(ref subject, value);
        }
        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }
        public int Status {
            get => status;
            set => SetProperty(ref status, value);
        }
        public int Label {
            get => label;
            set => SetProperty(ref label, value);
        }
        public string Location {
            get => location;
            set => SetProperty(ref location, value);
        }
        public int CalendarId {
            get => calendarId;
            set => SetProperty(ref calendarId, value);
        }
        public string RecurrenceInfo {
            get => recurrenceInfo;
            set => SetProperty(ref recurrenceInfo, value);
        }
        public string TimeZoneId {
            get => timeZoneId;
            set => SetProperty(ref timeZoneId, value);
        }
    }
    public static class TeamData {
        static TeamData() {
            Random = new Random();
            Start = GetStart();

            Employees = new List<Employee>() {
                new Employee() { BirthDate = new DateTime(1978, 12, 08), FirstName = "Nancy", LastName = "Davolio" },
                new Employee() { BirthDate = new DateTime(1965, 02, 19), FirstName = "Andrew", LastName = "Fuller" },
                new Employee() { BirthDate = new DateTime(1968, 06, 26), FirstName = "Janet", LastName = "Leverling" },
                new Employee() { BirthDate = new DateTime(1993, 05, 03), FirstName = "Margaret", LastName = "Peacock" },
                new Employee() { BirthDate = new DateTime(1993, 10, 17), FirstName = "Steven", LastName = "Buchanan" },
                new Employee() { BirthDate = new DateTime(1999, 10, 17), FirstName = "Michael", LastName = "Suyama" },
            };
            Employees[0].BirthDate = Start.AddDays(4).AddYears(-30);
            Calendars = CreateCalendars().ToList();

            VacationAppointments = CreateVacationsAppointments(Start).ToList();
            CompanyBirthdayAppointments = CreateCompanyBirthdayAppointments(Start).ToList();
            BirthdayAppointments = CreateBirthdayAppointments().ToList();
            ConferenceAppointments = CreateConferenceAppointments(Start).ToList();
            MeetingAppointments = CreateMeetingAppointments(Start).ToList();
            PhoneCallsAppointments = CreatePhoneCallsAppointments(Start).ToList();
            CarWashAppointments = CreateCarWashAppointments(Start).ToList();
            TrainingAppointments = CreateTrainingAppointments(Start).ToList();
            PayBillsAppointments = CreatePayBillsAppointments(Start).ToList();
            DentistAppointments = CreateDentistAppointments(Start).ToList();
            RestaurantAppointments = CreateRestaurantAppointments(Start).ToList();
            AllAppointments = VacationAppointments
                .Concat(BirthdayAppointments)
                .Concat(CompanyBirthdayAppointments)
                .Concat(ConferenceAppointments)
                .Concat(MeetingAppointments)
                .Concat(PhoneCallsAppointments)
                .Concat(CarWashAppointments)
                .Concat(TrainingAppointments)
                .Concat(PayBillsAppointments)
                .Concat(DentistAppointments)
                .Concat(RestaurantAppointments)
                .ToList();
            int id = 0;
            foreach (TeamAppointment apt in AllAppointments)
                apt.Id = id++;
        }
        public static DateTime Start { get; private set; }
        public static IEnumerable<TeamCalendar> Calendars { get; private set; }
        public static TeamCalendar MyCalendar { get { return Calendars.ElementAt(0); } }
        public static TeamCalendar TeamCalendar { get { return Calendars.ElementAt(1); } }
        public static IEnumerable<TeamAppointment> AllAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> VacationAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> BirthdayAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> ConferenceAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> MeetingAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> PhoneCallsAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> CarWashAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> CompanyBirthdayAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> TrainingAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> PayBillsAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> DentistAppointments { get; private set; }
        public static IEnumerable<TeamAppointment> RestaurantAppointments { get; private set; }

        static readonly List<Employee> Employees;
        static readonly Random Random;

        static DateTime GetStart() {
            DateTime today = DateTime.Today;
            DayOfWeek dayOfWeek = today.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Monday)
                return today;
            if (dayOfWeek == DayOfWeek.Sunday)
                return today.AddDays(1);
            return today.AddDays(-((int)dayOfWeek - 1));
        }
        static Employee GetRandomEmployee() {
            return Employees[Random.Next(0, Employees.Count)];
        }
        static IEnumerable<TeamCalendar> CreateCalendars() {
            return new TeamCalendar[] {
                new TeamCalendar() { Id = 0, Name = "My Calendar" },
                new TeamCalendar() { Id = 1, Name = "Team Calendar" },
            };
        }

        static IEnumerable<TeamAppointment> CreateBirthdayAppointments() {
            return Employees.Select(CreateBirthdayAppointment);
        }
        static TeamAppointment CreateBirthdayAppointment(Employee employee) {
            DateTime date = employee.BirthDate;
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Pattern,
                AllDay = true,
                Start = date,
                End = date.AddDays(1),
                Subject = string.Format("{0}'s Birthday", employee.FirstName),
                Status = 0,
                Label = 8,
                CalendarId = 0,
            };
            apt.RecurrenceInfo = new RecurrenceInfo() {
                AllDay = true,
                Start = date,
                Month = date.Month,
                DayNumber = date.Day,
                WeekOfMonth = WeekOfMonth.None,
                Type = RecurrenceType.Yearly,
                Range = RecurrenceRange.NoEndDate
            }.ToXml();
            return apt;
        }

        static IEnumerable<TeamAppointment> CreateConferenceAppointments(DateTime start) {
            DateTime newStart = start;
            Tuple<string, DateTime>[] thisWeekList = {
                Tuple.Create("DevExpress MVVM Framework", newStart.AddDays(1).AddHours(15)),
                Tuple.Create("New Theme Designer", newStart.AddDays(2).AddHours(14)),
                Tuple.Create("GridControl Performance Optimization", newStart.AddDays(3).AddHours(16)),
                Tuple.Create("WinForms and DirectX", newStart.AddDays(4).AddHours(16)),
            };

            newStart = start.AddDays(-7);
            Tuple<string, DateTime>[] prevWeekList = {
                Tuple.Create("LOB applications", newStart.AddDays(1).AddHours(13)),
                Tuple.Create("Module Injection Framework", newStart.AddDays(2).AddHours(16)),
                Tuple.Create("Git tricks", newStart.AddDays(3).AddHours(10)),
                Tuple.Create("Machine learning", newStart.AddDays(4).AddHours(11)),
            };

            newStart = start.AddDays(7);
            Tuple<string, DateTime>[] nextWeekList = {
                Tuple.Create("Azure", newStart.AddDays(1).AddHours(13)),
                Tuple.Create("WCF Services", newStart.AddDays(2).AddHours(16)),
                Tuple.Create("Docking Floating Panels", newStart.AddDays(3).AddHours(10)),
                Tuple.Create("Personal Time Management", newStart.AddDays(4).AddHours(11)),
            };

            newStart = start.AddDays(14);
            Tuple<string, DateTime>[] nextNextWeekList = {
                Tuple.Create("Entity Framework Core", newStart.AddDays(1).AddHours(10)),
                Tuple.Create(".Net Core", newStart.AddDays(2).AddHours(16)),
            };

            IEnumerable<Tuple<string, DateTime>> list = thisWeekList.Concat(prevWeekList).Concat(nextWeekList).Concat(nextNextWeekList);

            List<Tuple<string, DateTime>> commonList = new List<Tuple<string, DateTime>>();
            DateTimeRange interval = new DateTimeRange(start.AddDays(-7), start.AddDays(21));
            IEnumerable<string> subjects = list.Select(x => x.Item1);
            for (int i = 0; i < 100; i++) {
                newStart = start.AddYears(-1);
                newStart = newStart.AddDays(Random.Next(2 * 365));
                newStart = newStart.AddHours(Random.Next(9, 18));
                if (interval.Start <= newStart && interval.End >= newStart)
                    continue;
                string subj = subjects.ElementAt(Random.Next(0, subjects.Count()));
                commonList.Add(Tuple.Create(subj, newStart));
            }
            return list.Concat(commonList).Select(x => CreateConferenceAppointment(x.Item1, x.Item2));

        }
        static TeamAppointment CreateConferenceAppointment(string subject, DateTime start) {
            Employee emp = GetRandomEmployee();
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Normal,
                AllDay = false,
                Start = start,
                End = start.AddHours(1.5),
                Subject = string.Format("Conference: {0}", subject),
                Description = string.Format("{0} {1} tells us about {2}.", emp.FirstName, emp.LastName, subject),
                Status = 2,
                Label = 2,
                Location = "Conference Room",
                CalendarId = 1,
            };
            return apt;
        }
        static IEnumerable<TeamAppointment> CreateMeetingAppointments(DateTime start) {
            List<TeamAppointment> res = new List<TeamAppointment>() {
                CreateMeetingRecurrenceAppointment("Weekly meeting", start.AddMonths(-6).Add(new TimeSpan(5, 14, 00, 0))),
                CreateLunchAppointment(Employees[0], start.AddDays(1).AddHours(13)),
                CreateLunchAppointment(Employees[1], start.AddDays(3).AddHours(13)),
                CreateLunchAppointment(Employees[2], start.AddDays(-4).AddHours(13)),
                CreateLunchAppointment(Employees[3], start.AddDays(9).AddHours(13)),
                CreateLunchAppointment(Employees[4], start.AddDays(12).AddHours(13)),
            };
            DateTimeRange interval = new DateTimeRange(start.AddDays(-7), start.AddDays(21));
            List<int> days = new List<int>();
            for (int i = 0; i < 50; i++) {
                Employee emp = Employees[Random.Next(0, Employees.Count)];
                DateTime newStart = start.AddYears(-1);
                newStart = newStart.AddDays(Random.Next(365));
                if (interval.Start <= newStart && interval.End >= newStart)
                    continue;
                if (days.Contains(newStart.DayOfYear))
                    continue;
                if (VacationAppointments.Any(x => x.Start <= newStart && x.End >= newStart))
                    continue;
                days.Add(newStart.DayOfYear);
                res.Add(CreateLunchAppointment(emp, newStart.AddHours(13)));
            }
            return res;
        }
        static TeamAppointment CreateMeetingRecurrenceAppointment(string subject, DateTime start) {
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Pattern,
                AllDay = false,
                Start = start,
                End = start.AddHours(1),
                Subject = subject,
                Status = 2,
                Label = 2,
                CalendarId = 1,
            };
            apt.RecurrenceInfo = new RecurrenceInfo() {
                Start = start,
                Type = RecurrenceType.Weekly,
                WeekDays = WeekDays.Friday,
                Month = 12,
                Range = RecurrenceRange.NoEndDate
            }.ToXml();
            return apt;
        }
        static TeamAppointment CreateLunchAppointment(Employee emp, DateTime start) {
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Normal,
                AllDay = false,
                Start = start,
                End = start.AddHours(1),
                Subject = string.Format("Lunch with {0}", emp.FirstName),
                Status = 3,
                Label = 3,
                CalendarId = 0,
            };
            return apt;
        }

        static IEnumerable<TeamAppointment> CreatePhoneCallsAppointments(DateTime start) {
            List<TeamAppointment> res = new List<TeamAppointment>() {
                CreatePhoneCallAppointment(Employees[0], start.AddDays(0).AddHours(10)),
                CreatePhoneCallAppointment(Employees[1], start.AddDays(3).AddHours(11)),
                CreatePhoneCallAppointment(Employees[2], start.AddDays(3).AddHours(12).AddMinutes(40), TimeSpan.FromMinutes(15)),
                CreatePhoneCallAppointment(Employees[3], start.AddDays(-4).AddHours(14)),
                CreatePhoneCallAppointment(Employees[4], start.AddDays(9).AddHours(15)),
                CreatePhoneCallAppointment(Employees[5], start.AddDays(12).AddHours(15)),

                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(0).AddHours(16)),
                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(2).AddHours(15.6)),
                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(4).AddHours(15)),
                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(5).AddHours(10.5)),
                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(5).AddHours(16)),
                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(6).AddHours(9.7)),
                CreatePhoneCallAppointment(GetRandomEmployee(), start.AddDays(6).AddHours(16.8)),
            };
            DateTimeRange interval = new DateTimeRange(start.AddDays(-7), start.AddDays(21));
            for (int i = 0; i < 50; i++) {
                Employee emp = Employees[Random.Next(0, Employees.Count)];
                DateTime newStart = start.AddYears(-1);
                newStart = newStart.AddDays(Random.Next(365));
                if (interval.Start <= newStart && interval.End >= newStart)
                    continue;
                if (VacationAppointments.Any(x => x.Start <= newStart && x.End >= newStart))
                    continue;
                res.Add(CreatePhoneCallAppointment(emp, newStart.AddHours(Random.Next(9, 18))));
            }
            return res;
        }
        static TeamAppointment CreatePhoneCallAppointment(Employee emp, DateTime start, TimeSpan? duration = null) {
            DateTime newStart = start.AddMinutes(Random.Next(0, 4) * 15);
            DateTime newEnd = duration != null
                ? newStart.Add(duration.Value)
                : newStart.AddMinutes(Random.Next(1, 6) * 5);
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Normal,
                AllDay = false,
                Start = newStart,
                End = newEnd,
                Subject = string.Format("Phone Call with {0}", emp.FirstName),
                Status = 2,
                Label = 10,
                CalendarId = 0,
            };
            return apt;
        }

        static IEnumerable<TeamAppointment> CreateVacationsAppointments(DateTime start) {
            return new[] {
                new TeamAppointment() {
                    AppointmentType = (int)AppointmentType.Normal,
                    AllDay = true,
                    Start = start.AddMonths(-6),
                    End = start.AddMonths(-6).AddDays(14),
                    Subject = string.Format("Vacation"),
                    Status = 0,
                    Label = 4,
                    CalendarId = 0,
                },
                new TeamAppointment() {
                    AppointmentType = (int)AppointmentType.Normal,
                    AllDay = true,
                    Start = start.AddMonths(6),
                    End = start.AddMonths(6).AddDays(14),
                    Subject = string.Format("Vacation"),
                    Status = 0,
                    Label = 4,
                    CalendarId = 0,
                },
                new TeamAppointment() {
                    AppointmentType = (int)AppointmentType.Normal,
                    AllDay = true,
                    Start = start.AddDays(4),
                    End = start.AddDays(8),
                    Subject = string.Format("Vacation"),
                    Status = 0,
                    Label = 4,
                    CalendarId = 0,
                },
            };
        }

        static IEnumerable<TeamAppointment> CreateCarWashAppointments(DateTime start) {
            List<TeamAppointment> res = new List<TeamAppointment>() {
                CreateCarWashAppointment(start.AddDays(1).AddHours(17)),
            };
            DateTime newStart = start.AddYears(-1);
            while (newStart < start.AddMonths(1)) {
                newStart = newStart.AddDays(Random.Next(18, 35));
                if (VacationAppointments.Any(x => x.Start <= newStart && x.End >= newStart))
                    continue;
                if (newStart >= start && newStart <= start.AddDays(7))
                    continue;
                CreateCarWashAppointment(newStart);
            }
            return res;
        }
        static TeamAppointment CreateCarWashAppointment(DateTime start) {
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Normal,
                AllDay = false,
                Start = start,
                End = start.AddHours(1),
                Subject = string.Format("Car Wash"),
                Status = 3,
                Label = 3,
                CalendarId = 0,
            };
            return apt;
        }

        static IEnumerable<TeamAppointment> CreateCompanyBirthdayAppointments(DateTime start) {
            DateTime newStart = new DateTime(start.Year - 1, start.Month, start.Day);
            newStart = newStart.AddDays(5);
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Pattern,
                AllDay = true,
                Start = newStart,
                End = newStart.AddDays(1),
                Subject = "Company Birthday Party",
                Status = 0,
                Label = 8,
                CalendarId = 1,
            };
            apt.RecurrenceInfo = new RecurrenceInfo() {
                AllDay = true,
                Start = newStart,
                Type = RecurrenceType.Yearly,
                Month = newStart.Month,
                DayNumber = newStart.Day,
                WeekOfMonth = WeekOfMonth.None,
                Range = RecurrenceRange.NoEndDate
            }.ToXml();

            return new[] { apt };
        }

        static IEnumerable<TeamAppointment> CreateTrainingAppointments(DateTime start) {
            DateTime newStart = start.AddYears(-1).AddHours(8.5);
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Pattern,
                AllDay = false,
                Start = newStart,
                End = newStart.AddHours(1.5),
                Subject = "Sport Training",
                Status = 1,
                Label = 3,
                CalendarId = 0,
            };
            apt.RecurrenceInfo = new RecurrenceInfo() {
                AllDay = false,
                Start = newStart,
                Type = RecurrenceType.Weekly,
                WeekDays = WeekDays.Monday | WeekDays.Wednesday | WeekDays.Friday,
                Range = RecurrenceRange.NoEndDate
            }.ToXml();
            return new[] { apt };
        }

        static IEnumerable<TeamAppointment> CreatePayBillsAppointments(DateTime start) {
            DateTime newStart = start.AddDays(2).AddYears(-1);
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Pattern,
                AllDay = true,
                Start = newStart,
                End = newStart.AddDays(1),
                Subject = "Pay Bills",
                Status = 0,
                Label = 3,
                CalendarId = 0,
            };
            apt.RecurrenceInfo = new RecurrenceInfo() {
                AllDay = true,
                Start = newStart,
                Type = RecurrenceType.Monthly,
                DayNumber = newStart.Day,
                WeekOfMonth = WeekOfMonth.None,
                Range = RecurrenceRange.NoEndDate,
            }.ToXml();
            return new[] { apt };
        }

        static IEnumerable<TeamAppointment> CreateDentistAppointments(DateTime start) {
            List<TeamAppointment> res = new List<TeamAppointment>() {
                CreateDentistAppointment(start.AddDays(4).AddHours(17.5)),
            };
            DateTime newStart = start.AddYears(-2);
            while (newStart < start) {
                newStart = newStart.AddDays(Random.Next(365 / 3, 365 / 2));
                CreateDentistAppointment(newStart);
            }
            return res;
        }
        static TeamAppointment CreateDentistAppointment(DateTime start) {
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Normal,
                AllDay = false,
                Start = start,
                End = start.AddHours(2),
                Subject = string.Format("Dentist"),
                Status = 3,
                Label = 3,
                CalendarId = 0,
            };
            return apt;
        }

        static IEnumerable<TeamAppointment> CreateRestaurantAppointments(DateTime start) {
            List<TeamAppointment> res = new List<TeamAppointment>() {
                CreateDinnerAppointment(start.AddDays(2).AddHours(19)),
                CreateDinnerAppointment(start.AddDays(14).AddHours(19)),
                CreateDinnerAppointment(start.AddDays(18).AddHours(21)),
            };
            DateTime newStart = start.AddYears(-2);
            while (newStart < start) {
                newStart = newStart.AddDays(Random.Next(14, 42));
                res.Add(CreateDinnerAppointment(newStart.AddHours(Random.Next(18, 22))));
            }
            return res;
        }
        static TeamAppointment CreateDinnerAppointment(DateTime start, TimeSpan? duration = null) {
            DateTime newStart = start.AddMinutes(Random.Next(0, 4) * 15);
            DateTime newEnd = duration != null
                ? newStart.Add(duration.Value)
                : newStart.AddMinutes(Random.Next(4, 8) * 20);
            var apt = new TeamAppointment() {
                AppointmentType = (int)AppointmentType.Normal,
                AllDay = false,
                Start = newStart,
                End = newEnd,
                Subject = string.Format("Dinner"),
                Status = 0,
                Label = 5,
                CalendarId = 0,
            };
            return apt;
        }
    }
}
