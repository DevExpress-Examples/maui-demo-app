using System;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public enum Priority { Low, BelowNormal, Normal, AboveNormal, High }

    public class OutlookData {
        public int Id { get; set; }
        public string Subject { get; set; }
        public Customer From { get; set; }
        public DateTime Sent { get; set; }
        public TimeSpan Time { get; set; }
        public bool HasAttachment { get; set; }
        public long Size { get; set; }
        public double HoursActive { get; set; }
        public Priority Priority { get; set; }
    }
}
