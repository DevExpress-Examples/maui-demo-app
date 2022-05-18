using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.Models;
using DemoCenter.Maui.Views;

namespace DemoCenter.Maui.Data {
    public class SchedulerData : IDemoData {
        public static DemoItem GetItem(Type module) {
            IEnumerable<DemoItem> items = demoItems.Where((d) => d.Module == module);
            return items.Any() ? items.Last() : null;
        }

        static readonly List<DemoItem> demoItems;

        static SchedulerData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Calendar",
                    Description = "A calendar that allows a user to select a date. The calendar highlights holidays and observances.",
                    Module = typeof(CalendarView),
                    DemoItemStatus = DemoItemStatus.New,
                    Icon = "calendar"
                },
                new DemoItem() {
                    Title = "Day View",
                    Description="This is a detailed view of appointments for one or several days.",
                    Module = typeof(DayViewDemo),
                    Icon = "dayview"
                },
                 new DemoItem() {
                    Title = "Work Week View",
                    Description="Displays appointments for working days in a week.",
                    Module = typeof(ReceptionDesk),
                    Icon = "workweekview"
                 },
                new DemoItem() {
                    Title = "Week View",
                    Description="Displays appointments for an entire week.",
                    Module = typeof(WeekViewDemo),
                    Icon = "weekview"
                },
                new DemoItem() {
                    Title = "Month View",
                    Description="An overview of appointments for a month.",
                    Module = typeof(MonthViewDemo),
                    Icon = "monthview"
                },
                //new DemoItem() {
                //    Title = "Reminders",
                //    Description="Illustrates how to add reminders to appointments.",
                //    Module = typeof(RemindersDemo),
                //    Icon = "reminders",
                //    ShowItemUnderline = false},
            };
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title => "SchedulerView";
    }
}
