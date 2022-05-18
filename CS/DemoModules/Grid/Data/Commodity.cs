using DemoCenter.Maui.ViewModels;

namespace DemoCenter.Maui.DemoModules.Grid.Data {
    public class Commodity : NotificationObject {
        readonly string name;

        public string Name {
            get { return this.name; }
        }

        public Commodity(string name) {
            this.name = name;
        }
    }
}
