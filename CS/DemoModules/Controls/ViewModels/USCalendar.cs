using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DemoCenter.Maui.ViewModels {
    public abstract class SpecialDate {
        protected SpecialDate(DateTime date, string description) {
            Date = date;
            Description = description;
        }

        public DateTime Date { get; }
        public string Description { get; }
        public abstract bool IsHoliday { get; }
    }

    public class FederalHoliday : SpecialDate {
        public FederalHoliday(DateTime date, string description) : base(date, description) {
        }

        public override bool IsHoliday => true;
    }

    public class Observance : SpecialDate {
        public Observance(DateTime date, string description) : base(date, description) {
        }

        public override bool IsHoliday => false;
    }

    public class USCalendar {
        #region Static methods
        static bool IsMonday(DateTime date) {
            return date.DayOfWeek == DayOfWeek.Monday;
        }
        static bool IsFriday(DateTime date) {
            return date.DayOfWeek == DayOfWeek.Friday;
        }
        static DateTime GetDayOfMonth(int year, int month, DayOfWeek dayOfWeek, int occurrence) {
            DateTime date = new DateTime(year, month, 1);
            for (int i = 1; i <= 7; i++) {
                if (date.DayOfWeek == dayOfWeek)
                    break;

                date = date.AddDays(1);
            }
            return date.AddDays(7 * (occurrence - 1));
        }

        static DateTime GetLastDayOfWeekInMonth(int year, int month, DayOfWeek dayOfWeek) {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime date = new DateTime(year, month, daysInMonth);
            for (int i = 7; i >= 1; i--) {
                if (date.DayOfWeek == dayOfWeek)
                    break;

                date = date.AddDays(-1);
            }
            return date;
        }

        static void AddFederalHolidayTo(List<SpecialDate> specialDates, DateTime holiday, string description) {
            specialDates.Add(new FederalHoliday(holiday, description));
            // DateTime prevHoliday = holiday.AddDays(-1);
            // if (IsFriday(prevHoliday))
            //     specialDates.Add(new FederalHoliday(prevHoliday, description));
            // DateTime nextHoliday = holiday.AddDays(1);
            // if (IsMonday(nextHoliday))
            //     specialDates.Add(new FederalHoliday(nextHoliday, description));
        }

        static DateTime GetEasterSunday(int year) {
            int g = year % 19;
            int c = year / 100;
            int h = (c - (c / 4) - ((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));

            int day = i - ((year + (year / 4) + i + 2 - c + (c / 4)) % 7) + 28;
            int month = 3;

            if (day > 31) {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

        static List<SpecialDate> GetSpecialDates(int year) {
            List<SpecialDate> specialDates = new List<SpecialDate>();

            //Federal holidays
            AddFederalHolidayTo(specialDates, new DateTime(year, 1, 1), "New Year's Day");
            AddFederalHolidayTo(specialDates, new DateTime(year + 1, 1, 1), "New Year's Day");

            DateTime date = GetDayOfMonth(year, 1, DayOfWeek.Monday, 3);
            specialDates.Add(new FederalHoliday(date, "Martin Luther King Jr. Day"));

            date = GetDayOfMonth(year, 2, DayOfWeek.Monday, 3);
            specialDates.Add(new FederalHoliday(date, "Presidents' Day"));

            date = GetLastDayOfWeekInMonth(year, 5, DayOfWeek.Monday);
            specialDates.Add(new FederalHoliday(date, "Memorial Day"));

            AddFederalHolidayTo(specialDates, new DateTime(year, 6, 19), "Juneteenth");
            AddFederalHolidayTo(specialDates, new DateTime(year, 7, 4), "Independence Day");

            date = GetDayOfMonth(year, 9, DayOfWeek.Monday, 1);
            specialDates.Add(new FederalHoliday(date, "Labor Day"));

            date = GetDayOfMonth(year, 10, DayOfWeek.Monday, 2);
            specialDates.Add(new FederalHoliday(date, "Columbus Day"));

            AddFederalHolidayTo(specialDates, new DateTime(year, 11, 11), "Veterans Day");

            date = GetDayOfMonth(year, 11, DayOfWeek.Thursday, 4);
            specialDates.Add(new FederalHoliday(date, "Thanksgiving"));

            AddFederalHolidayTo(specialDates, new DateTime(year, 12, 25), "Christmas Day");

            //Observances
            date = new DateTime(year, 2, 14);
            specialDates.Add(new Observance(date, "Valentine's Day"));

            date = new DateTime(year, 3, 17);
            specialDates.Add(new Observance(date, "St. Patrick's Day"));

            date = GetEasterSunday(year);
            specialDates.Add(new Observance(date, "Easter"));
            specialDates.Add(new Observance(date.AddDays(1), "Easter Monday"));

            date = new DateTime(year, 5, 5);
            specialDates.Add(new Observance(date, "Cinco de Mayo"));

            date = GetDayOfMonth(year, 5, DayOfWeek.Sunday, 2);
            specialDates.Add(new Observance(date, "Mother's Day"));

            date = new DateTime(year, 6, 14);
            specialDates.Add(new Observance(date, "Flag Day"));

            date = GetDayOfMonth(year, 6, DayOfWeek.Sunday, 3);
            specialDates.Add(new Observance(date, "Father's Day"));

            date = new DateTime(year, 10, 31);
            specialDates.Add(new Observance(date, "Halloween"));

            date = GetDayOfMonth(year, 11, DayOfWeek.Monday, 1).AddDays(1);
            specialDates.Add(new Observance(date, "Election Day"));

            date = GetDayOfMonth(year, 11, DayOfWeek.Thursday, 4).AddDays(1);
            specialDates.Add(new Observance(date, "Black Friday"));

            date = new DateTime(year, 12, 24);
            specialDates.Add(new Observance(date, "Christmas Eve"));

            date = new DateTime(year, 12, 31);
            specialDates.Add(new Observance(date, "New Year's Eve"));

            specialDates = specialDates.Where(specialDate => specialDate.Date.Year == year).ToList();
            SortSpecialDates(specialDates);
            return specialDates;
        }

        static void SortSpecialDates(List<SpecialDate> list) {
            list.Sort((x, y) => x.Date == y.Date ? x.IsHoliday ? -1 : 1 : DateTime.Compare(x.Date, y.Date));
        }
        #endregion

        public USCalendar(int year) {
            Year = Year;
            SpecialDates = new ReadOnlyCollection<SpecialDate>(GetSpecialDates(year));
        }

        public int Year { get; }
        public ReadOnlyCollection<SpecialDate> SpecialDates { get; }

        public IEnumerable<SpecialDate> GetSpecialDatesForMonth(int month) {
            List<SpecialDate> specialDates = SpecialDates.Where(specialDate => specialDate.Date.Month == month).ToList();
            SortSpecialDates(specialDates);
            return specialDates;
        }


    }
}
