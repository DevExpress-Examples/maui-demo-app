using System;
using System.Collections.Generic;
using System.Linq;
using DemoCenter.Maui.ViewModels;
using DevExpress.Maui.Editors;

namespace DemoCenter.Maui.ViewModels {
    public class CalendarViewModel : NotificationObject {
        DateTime displayDate;
        DateTime? selectedDate;
        DXCalendarViewType activeViewType;
        bool isHolidaysAndObservancesListVisible;
        IEnumerable<SpecialDate> specialDates;

        public CalendarViewModel() {
            DisplayDate = DateTime.Today;
            UpdateHolidaysAndObservancesListVisible();
        }

        public IEnumerable<SpecialDate> SpecialDates {
            get => this.specialDates;
            set => SetProperty(ref this.specialDates, value);
        }

        public DateTime DisplayDate {
            get => this.displayDate;
            set => SetProperty(ref this.displayDate, value, () => {
                UpdateCurrentCalendarIfNeeded();
                SpecialDates = USCalendar.GetSpecialDatesForMonth(DisplayDate.Month);
            });
        }

        public DateTime? SelectedDate {
            get => this.selectedDate;
            set => SetProperty(ref this.selectedDate, value);
        }

        public DXCalendarViewType ActiveViewType {
            get => this.activeViewType;
            set => SetProperty(ref this.activeViewType, value, UpdateHolidaysAndObservancesListVisible);
        }

        public bool IsHolidaysAndObservancesListVisible {
            get => this.isHolidaysAndObservancesListVisible;
            set => SetProperty(ref this.isHolidaysAndObservancesListVisible, value);
        }

        USCalendar USCalendar { get; set; }

        public SpecialDate TryFindSpecialDate(DateTime date) {
            return SpecialDates.FirstOrDefault(x => x.Date == date);
        }

        void UpdateHolidaysAndObservancesListVisible() {
            IsHolidaysAndObservancesListVisible = ActiveViewType == DXCalendarViewType.Month;
        }

        void UpdateCurrentCalendarIfNeeded() {
            if (USCalendar == null || USCalendar.Year != DisplayDate.Year)
                USCalendar = new USCalendar(DisplayDate.Year);
        }
    }
}
