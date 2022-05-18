using System;
using SQLite;

namespace DemoCenter.Maui.ViewModels {
    [Table("Appointments")]
    public class ReminderAppointment : DataItem {
        int appointmentType;
        bool allDay;
        DateTime start;
        DateTime end;
        string subject;
        string description;
        int status;
        int label;
        string location;
        string reminderInfo;
        string recurrenceInfo;
        string timeZoneId;

        // keyword 'virtual' fails on AOT mode (ios) -> Microsoft bug on rc3
        //[PrimaryKey, AutoIncrement, Column("_id")]
        //public override int Id { get => base.Id; set => base.Id = value; }

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
        public string ReminderInfo {
            get => reminderInfo;
            set => SetProperty(ref reminderInfo, value);
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
}
