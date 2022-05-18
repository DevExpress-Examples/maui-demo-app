using System.Collections.Generic;
using System.Linq;
using SQLite;
using Microsoft.Maui.Controls;
using DemoCenter.Maui.DemoModules.Scheduler.Data.Reminders;

namespace DemoCenter.Maui.ViewModels {
    public partial class AppointmentRepository {
        const string APPOINTMENT_TABLE_NAME = "appointments.db";
        static AppointmentRepository appointmentsDB;
        static object collisionLock = new object();

        readonly SQLiteConnection database;

        public static AppointmentRepository Instance {
            get => appointmentsDB = appointmentsDB ?? new AppointmentRepository(APPOINTMENT_TABLE_NAME);
        }

        AppointmentRepository(string filename) {
            string path = new StoragePathProvider().GetPath(filename);
            database = new SQLiteConnection(path);
            database.CreateTable<ReminderAppointment>();
        }

        public IEnumerable<ReminderAppointment> GetItems() {
            lock (collisionLock) 
                return (from i in database.Table<ReminderAppointment>() select i).ToList();
        }
        public ReminderAppointment GetItem(int id) {
            lock (collisionLock) 
                return database.Get<ReminderAppointment>(id);              
        }
        public int DeleteItem(int id) {
            lock (collisionLock)
                return database.Delete<ReminderAppointment>(id);
        }
        public int SaveItem(ReminderAppointment item) {
            lock (collisionLock) {
                if (item.Id == 0)
                    return database.Insert(item);
                database.Update(item);
                return item.Id;
            }
        }
    }
}
