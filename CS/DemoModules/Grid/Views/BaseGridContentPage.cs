using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace DemoCenter.Maui.Views {
    public abstract class BaseGridContentPage : Demo.DemoPage {
        public BaseGridContentPage() {
            On<Microsoft.Maui.Controls.PlatformConfiguration.iOS>().SetUseSafeArea(false);
            BindData();
        }
        
        async void BindData() {
            BindingContext = await Task.Run(() => LoadData());
        }

        protected abstract object LoadData();
    }
}
