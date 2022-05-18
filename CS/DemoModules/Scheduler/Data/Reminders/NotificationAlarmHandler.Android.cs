using System;
using Android.OS;
using Android.Media;
using Android.Content;
using AndroidX.Core.App;
using AAplication = Android.App.Application;
using Android.App;

namespace DemoCenter.Maui.DemoModules.Scheduler.Data.Reminders {
    public static class IntentExtensions {
        public static Guid GetReminderId(this Intent intent) {
            string guidString = intent.GetStringExtra(NotificationAlarmHandler.ReminderId);
            if (String.IsNullOrEmpty(guidString))
                return Guid.Empty;
            try {
                return Guid.Parse(guidString);
            } catch {
                return Guid.Empty;
            }
        }

        public static int GetRecurrenceIndex(this Intent intent) {
            return intent.GetIntExtra(NotificationAlarmHandler.RecurrenceIndex, -1);
        }
    }

    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { NotificationHandler })]
    public class NotificationAlarmHandler : BroadcastReceiver {
        public const string NotificationHandler = "NotificationAlarmHandler";
        public const string ReminderId = "ReminderId";
        public const string RecurrenceIndex = "RecurrenceIndex";
        public const string Subject = "Subject";
        public const string Interval = "Interval";


        static Intent GetLauncherActivity() {
            return AAplication.Context.PackageManager.GetLaunchIntentForPackage(CurrentPackageName);
        }

        static string CurrentPackageName => AAplication.Context.PackageName;
        static string ReminderChannelId => $"{CurrentPackageName}.reminders";

        readonly NotificationChannel notificationChannel;
        NotificationManager NotificationManager => (NotificationManager)AAplication.Context.GetSystemService(Context.NotificationService);

        public NotificationAlarmHandler() {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O) {
                this.notificationChannel = new NotificationChannel(ReminderChannelId, "Reminders", NotificationImportance.High);
                this.notificationChannel.EnableVibration(true);
                this.notificationChannel.EnableLights(true);
                this.notificationChannel.SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm), new AudioAttributes.Builder()
                    .SetContentType(AudioContentType.Sonification)
                    .SetUsage(AudioUsageKind.Alarm)
                    .Build());
                this.notificationChannel.Importance = NotificationImportance.High;
                NotificationManager.CreateNotificationChannel(this.notificationChannel);
            }
        }

        public override void OnReceive(Context context, Intent intent) {
            Guid reminderId = intent.GetReminderId();
            if (reminderId == Guid.Empty)
                return;

            int notificationId = reminderId.GetHashCode();

            Intent resultIntent = GetLauncherActivity().PutExtras(intent.Extras).SetFlags(ActivityFlags.SingleTop /*| ActivityFlags.ClearTop*/);
            PendingIntent resultPendingIntent = PendingIntent.GetActivity(context, notificationId, resultIntent, PendingIntentFlags.UpdateCurrent | PendingIntentFlags.Mutable);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(AAplication.Context, ReminderChannelId);
            builder.SetContentIntent(resultPendingIntent);
            builder.SetDefaults((int)NotificationDefaults.All);

            builder.SetContentTitle(intent.GetStringExtra(Subject));
            builder.SetContentText(intent.GetStringExtra(Interval));
            builder.SetSmallIcon(Resource.Mipmap.appicon);
            builder.SetChannelId(ReminderChannelId);
            builder.SetPriority((int)NotificationPriority.High);
            builder.SetAutoCancel(true);
            builder.SetVisibility((int)NotificationVisibility.Public);
            NotificationManager.Notify(notificationId, builder.Build());
        }
    }
}

