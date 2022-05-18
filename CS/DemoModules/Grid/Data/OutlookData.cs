using System;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public enum Priority { Low, BelowNormal, Normal, AboveNormal, High }

    public class OutlookData {
        public int Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual Customer From { get; set; }
        public virtual DateTime Sent { get; set; }
        public virtual TimeSpan Time { get; set; }
        public virtual bool HasAttachment { get; set; }
        public virtual long Size { get; set; }
        public virtual double HoursActive { get; set; }
        public virtual Priority Priority { get; set; }
    }
}
