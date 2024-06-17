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
                    Description = "A calendar that allows a user to select a date. The calendar can highlight holidays, observances, and any specific days in the year.",
                    Module = typeof(CalendarView),
                    Icon = "calendar"
                },
                new DemoItem() {
                    Title = "Agenda View",
                    Description="This view displays appointments in a list.",
                    Module = typeof(AgendaViewDemo),
                    DemoItemStatus = DemoItemStatus.New,
                    Icon = "agendaview"
                },
                new DemoItem() {
                    Title = "Day View",
                    Description="This scheduler view displays appointments for one or more days.",
                    Module = typeof(DayViewDemo),
                    Icon = "dayview"
                },
                 new DemoItem() {
                    Title = "Work Week View",
                    Description="This scheduler view displays appointments for weekdays only.",
                    Module = typeof(ReceptionDesk),
                    Icon = "workweekview"
                 },
                new DemoItem() {
                    Title = "Week View",
                    Description="This view displays appointments for the entire week.",
                    Module = typeof(WeekViewDemo),
                    Icon = "weekview"
                },
                new DemoItem() {
                    Title = "Month View",
                    Description="An overview of appointments for a month.",
                    Module = typeof(MonthViewDemo),
                    Icon = "monthview"
                },
                
                
                
                
                
                
            };
        }
        public List<DemoItem> DemoItems => demoItems;
        public string Title => TitleData.SchedulerDataTitle;
    }
}
