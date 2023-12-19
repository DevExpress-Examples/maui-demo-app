using System.Collections.Generic;
using DevExpress.Maui.Scheduler;

namespace DemoCenter.Maui;
public partial class RemindersNotificationCenter {
    const int MaxNotificationsCount = 32;

    public void UpdateNotifications(SchedulerDataStorage storage) {
        IList<TriggeredReminder> futureReminders = storage.GetNextReminders(MaxNotificationsCount);
        UpdateNotificationsCore(futureReminders, MaxNotificationsCount);
    }
}
