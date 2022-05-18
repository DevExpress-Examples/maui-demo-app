using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using DemoCenter.Maui;
using DevExpress.Maui.Scheduler;
using Foundation;
using Microsoft.Maui.Controls;
using UIKit;
using UserNotifications;

namespace DemoCenter.Maui.DemoModules.Scheduler.Data.Reminders {
    public partial class NotificationCenter : NSObject, INotificationCenter {
        #region Neasted classes
        public class ReminderIdentifier {
            public Guid Guid { get; private set; }
            public int RecurrenceIndex { get; private set; }

            public ReminderIdentifier(Guid guid, int recurrenceIndex) {
                Guid = guid;
                RecurrenceIndex = recurrenceIndex;
            }
        }
        #endregion
        #region Static methods
        public static string SerializeReminder(TriggeredReminder reminder) {
            return reminder.Id + ":" + reminder.Appointment.RecurrenceIndex.ToString();
        }
        public static ReminderIdentifier DeserializeReminder(string reminderIdentifier) {
            string[] splitData = reminderIdentifier.Split(':');
            string recurrenceId = splitData[0];
            int recurrenceIndex = Int32.Parse(splitData[1]);
            Guid reminderGuid = Guid.Parse(recurrenceId);
            return new ReminderIdentifier(reminderGuid, recurrenceIndex);
        }
        #endregion

        readonly ReminderNotificationCenterCore notificationsCore;

        public NotificationCenter() {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                notificationsCore = new ReminderNotificationCenterVersionSinceX();
            else
                notificationsCore = new ReminderNotificationCenterVersionBeforeX();
        }

        public void UpdateNotifications(IList<TriggeredReminder> reminders, int maxCount) {
            notificationsCore.UpdateRemindersNotifications(reminders);
        }
    }

    public abstract class ReminderNotificationCenterCore {
        protected string CreateMessageContent(TriggeredReminder reminder) {
            return reminder.Appointment.Interval.ToString("{0:g} - {1:g}", null);
        }
        public abstract void UpdateRemindersNotifications(IList<TriggeredReminder> featureReminders);
    }

    public class ReminderNotificationCenterVersionBeforeX : ReminderNotificationCenterCore {

        void RequestUserAccess() {
            UIUserNotificationSettings settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Sound | UIUserNotificationType.Alert | UIUserNotificationType.Badge, null);
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }
        void ScheduleReminderNotification(TriggeredReminder reminder, int badge) {
            UILocalNotification notification = new UILocalNotification();
            notification.FireDate = NSDate.FromTimeIntervalSinceNow((reminder.AlertTime - DateTime.Now).TotalSeconds);
            notification.AlertBody = CreateMessageContent(reminder);
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
        public override void UpdateRemindersNotifications(IList<TriggeredReminder> featureReminders) {
            RequestUserAccess();
            UIApplication.SharedApplication.CancelAllLocalNotifications();
            for (int i = 0; i < featureReminders.Count; i++) {
                ScheduleReminderNotification(featureReminders[i], i + 1);
            }
        }
    }

    public class ReminderNotificationCenterVersionSinceX : ReminderNotificationCenterCore {
        readonly UNUserNotificationCenter notificationCenter = UNUserNotificationCenter.Current;

        Task<Tuple<bool, NSError>> RequestUserAccess() {
            UNAuthorizationOptions options = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.Badge;
            return notificationCenter.RequestAuthorizationAsync(options);
        }

        async void ScheduleReminderNotification(TriggeredReminder reminder, int badge) {
            UNMutableNotificationContent content = new UNMutableNotificationContent() {
                Title = reminder.Appointment.Subject,
                Body = CreateMessageContent(reminder),
                Sound = UNNotificationSound.Default,
                Badge = badge,
            };
            NSDateComponents dateComponents = new NSDateComponents() {
                Second = reminder.AlertTime.Second,
                Minute = reminder.AlertTime.Minute,
                Hour = reminder.AlertTime.Hour,
                Day = reminder.AlertTime.Day,
                Month = reminder.AlertTime.Month,
                Year = reminder.AlertTime.Year,
                TimeZone = NSTimeZone.SystemTimeZone,
            };
            UNCalendarNotificationTrigger trigger = UNCalendarNotificationTrigger.CreateTrigger(dateComponents, false);
            string identifier = NotificationCenter.SerializeReminder(reminder);
            UNNotificationRequest request = UNNotificationRequest.FromIdentifier(identifier, content, trigger);
            await notificationCenter.AddNotificationRequestAsync(request);
        }

        public override async void UpdateRemindersNotifications(IList<TriggeredReminder> featureReminders) {
            Tuple<bool, NSError> authResult = await RequestUserAccess();
            if (!authResult.Item1) {
                Debug.WriteLine("User denied access to notifications");
                return;
            }
            notificationCenter.RemoveAllPendingNotificationRequests();
            for (int i = 0; i < featureReminders.Count; i++) {
                ScheduleReminderNotification(featureReminders[i], i + 1);
            }
        }
    }
}