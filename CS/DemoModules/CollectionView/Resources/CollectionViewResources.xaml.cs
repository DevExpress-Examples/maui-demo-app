using Microsoft.Maui.Controls;

namespace DemoCenter.Maui.DemoModules.Resources {
    public partial class CollectionViewResources : ResourceDictionary {
        public CollectionViewResources() {
            InitializeComponent();
            Add("formatTime", @"{0:HH:mm}");
        }
    }
}
