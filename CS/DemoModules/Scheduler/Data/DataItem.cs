namespace DemoCenter.Maui.ViewModels {
    public class DataItem : NotificationObject {
        int id;

        public int Id {
            get => id;
            set => SetProperty(ref id, value);
        }
    }
}
