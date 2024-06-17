using System;
using System.Xml;
using DevExpress.Maui.Scheduler;
using DevExpress.Utils.Serializing;
using System.Collections.Generic;
using DevExpress.Maui.Scheduler.Internal;

namespace DemoCenter.Maui.ViewModels;

public static class ReminderHelper {
    public static string ToReminderXml(TimeSpan timeBeforeStart) {
        return new ReminderCollectionXmlPersistenceHelper([timeBeforeStart]).ToXml();
    }

    sealed class ReminderCollectionXmlPersistenceHelper : CollectionXmlPersistenceHelper {
        public ReminderCollectionXmlPersistenceHelper(List<TimeSpan> target) : base(target) {
        }
        protected override string XmlCollectionName { get { return nameof(AppointmentItem.Reminders); } }
        protected override ObjectCollectionXmlLoader CreateObjectCollectionXmlLoader(XmlNode root) {
            return null;
        }
        protected override IXmlContextItem CreateXmlContextItem(object obj) {
            return new ReminderContextElement((TimeSpan)obj);
        }
    }
    sealed class ReminderContextElement : XmlContextItem {
        readonly TimeSpan timeSpan;
        public ReminderContextElement(TimeSpan timeSpan)
            : base("Reminder", timeSpan, null) {
            this.timeSpan = timeSpan;
        }
        public override string ValueToString() {
            return new ReminderXmlPersistenceHelper(timeSpan).ToXml();
        }
    }
    sealed class ReminderXmlPersistenceHelper : XmlPersistenceHelper {
        readonly TimeSpan timeBeforeStart;
        public ReminderXmlPersistenceHelper(TimeSpan timeBeforeStart) {
            this.timeBeforeStart = timeBeforeStart;
        }
        public override ObjectXmlLoader CreateObjectXmlLoader(XmlNode root) {
            return null;
        }

        protected override IXmlContext GetXmlContext() {
            XmlContext context = new XmlContext("Reminder");
            context.Attributes.Add(new GuidContextAttribute("Id", Guid.NewGuid(), Guid.Empty));
            context.Attributes.Add(new TimeSpanContextAttribute("TimeBeforeStart", timeBeforeStart, TimeSpan.FromSeconds(15)));
            return context;
        }
    }
}

public static class RecurrenceHelper {
    public static int CalcWeeklyOccurrenceIndex(RecurrenceInfo recurrenceInfo, DateTime patternStart) {
        int occurrenceCount = 0;
        DateTime occurrenceStart = patternStart;
        while (occurrenceStart < DateTime.Now) {
            var dayOfWeek = occurrenceStart.DayOfWeek;
            if ((DateTimeHelper.ToWeekDays(dayOfWeek) & recurrenceInfo.WeekDays) != 0)
                occurrenceCount++;
            occurrenceStart = occurrenceStart.AddDays(1);
        }
        return occurrenceCount;
    }
    public static string ToPatternReference(RecurrenceInfo info, int occurrenceCount) {
        return new PatternReference(info.Id, occurrenceCount).ToXml();
    }
}