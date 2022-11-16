using System;
using System.IO;
using Microsoft.Maui.Controls;
using Java.Sql;
using Android.App;
using Android.Content;
using AAplication = Android.App.Application;
using DevExpress.Maui.Scheduler;
using DemoCenter.Maui;
using System.Collections.Generic;

namespace DemoCenter.Maui.DemoModules.Scheduler.Data.Reminders {
    public class NotificationCenter : Java.Lang.Object, INotificationCenter {
        Dictionary<int, PendingIntent> activePendingIntents = new Dictionary<int, PendingIntent>();

        static Date ToNativeDate(DateTime dateTime) {
            long dateTimeUtcAsMilliseconds = (long)dateTime.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            return new Date(dateTimeUtcAsMilliseconds);
        }

        void INotificationCenter.UpdateNotifications(IList<TriggeredReminder> reminders, int maxCount) {
            if (reminders.Count == 0 && this.activePendingIntents.Count == 0)
                return;

            AlarmManager alarm = (AlarmManager)AAplication.Context.GetSystemService(Context.AlarmService);
            for (int i = 0; i < maxCount; i++) {
                PendingIntent pendingIntent;
                if (this.activePendingIntents.TryGetValue(i, out pendingIntent)) {
                    alarm.Cancel(pendingIntent);
                    this.activePendingIntents.Remove(i);
                }

                if (i < reminders.Count) {
                    TriggeredReminder reminder = reminders[i];
                    pendingIntent = PendingIntent.GetBroadcast(AAplication.Context, i, CreateIntent(reminder), PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Mutable);
                    this.activePendingIntents.Add(i, pendingIntent);
                    alarm.Set((int)AlarmType.RtcWakeup, ToNativeDate(reminder.AlertTime).Time, pendingIntent);
                } 
            }
        }

        Intent CreateIntent() {
            return new Intent(AAplication.Context, typeof(NotificationAlarmHandler)).SetAction(NotificationAlarmHandler.NotificationHandler);
        }
        Intent CreateIntent(string id, int recurrenceIndex, string subject, string interval) {
            return CreateIntent()
                .PutExtra(NotificationAlarmHandler.ReminderId, id)
                .PutExtra(NotificationAlarmHandler.RecurrenceIndex, recurrenceIndex)
                .PutExtra(NotificationAlarmHandler.Subject, subject)
                .PutExtra(NotificationAlarmHandler.Interval, interval);
        }
        Intent CreateIntent(TriggeredReminder reminder) {
            AppointmentItem appointment = reminder.Appointment;
            return CreateIntent(reminder.Id.ToString(), appointment.RecurrenceIndex, appointment.Subject, appointment.Interval.ToString("{0:g} - {1:g}", null));
        }
    }
}

