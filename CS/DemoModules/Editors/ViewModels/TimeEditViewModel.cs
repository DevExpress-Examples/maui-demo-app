using System;
using System.Collections.Generic;
using DevExpress.Maui.Editors;

namespace DemoCenter.Maui.DemoModules.Editors.ViewModels {
    public class TimeEditViewModel: TextEditViewModel {
        TimeFormatItem selectedTimeFormatMode;
        public TimeEditViewModel() {
            TimeFormatModes = new List<TimeFormatItem> {
                new TimeFormatItem (){ Name="12 hour format", Value =TimeFormatMode.HourFormat12 },
                new TimeFormatItem (){ Name="24 hour format", Value =TimeFormatMode.HourFormat24 },
                new TimeFormatItem (){ Name="Current culture format", Value =TimeFormatMode.Auto }
            };
            this.selectedTimeFormatMode = TimeFormatModes[2];
        }
        public TimeFormatItem SelectedTimeFormatMode {
            get => this.selectedTimeFormatMode;
            set => SetProperty(ref this.selectedTimeFormatMode, value );
        }
        public IList<TimeFormatItem> TimeFormatModes { get; }
    }
    public class TimeFormatItem {
        public string Name { get; set; }
        public TimeFormatMode Value { get; set; }
    }
}
