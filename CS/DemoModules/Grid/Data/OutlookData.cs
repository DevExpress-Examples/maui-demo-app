using System;
using DevExpress.Maui.DataForm;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public enum Priority { Low, BelowNormal, Normal, AboveNormal, High }

    public class OutlookData {
        [DataFormItemPosition(RowOrder = 0)]
        public int Id { get; set; }
        [DataFormDisplayOptions(IsVisible = false)]
        public string Subject { get; set; }
        [DataFormDisplayOptions(IsVisible = false)]
        public Customer From { get; set; }
        [DataFormItemPosition(RowOrder = 2)]
        public DateTime Sent { get; set; }
        [DataFormItemPosition(RowOrder = 3)]
        public TimeSpan Time { get; set; }
        [DataFormCheckBoxEditor]
        [DataFormItemPosition(RowOrder = 6)]
        [DataFormDisplayOptions(LabelText = "Has Attachment")]
        public bool HasAttachment { get; set; }
        [DataFormItemPosition(RowOrder = 4)]
        public long Size { get; set; }
        [DataFormItemPosition(RowOrder = 5)]
        [DataFormDisplayOptions(LabelText = "Hours Active")]
        public double HoursActive { get; set; }
        [DataFormItemPosition(RowOrder = 1)]
        public Priority Priority { get; set; }
    }
}
