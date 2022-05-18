using System.Collections.Generic;
using DevExpress.Maui.Scheduler;

namespace DemoCenter.Maui {
    public interface INotificationCenter {
        void UpdateNotifications(IList<TriggeredReminder> reminders, int maxCount);
    }

    public class RemindersNotificationCenter {
        const int MaxNotificationsCount = 32;

        readonly INotificationCenter notificationCenter;

        public RemindersNotificationCenter() {
            this.notificationCenter = new DemoModules.Scheduler.Data.Reminders.NotificationCenter();
        }

        public void UpdateNotifications(SchedulerDataStorage storage) {
            IList<TriggeredReminder> futureReminders = storage.GetNextReminders(MaxNotificationsCount);
            this.notificationCenter.UpdateNotifications(futureReminders, MaxNotificationsCount);
        }
    }
}
