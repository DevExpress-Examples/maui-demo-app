using System.Globalization;
using System.Threading;
using Application = Microsoft.Maui.Controls.Application;
#if PaidDemoModules
using Microsoft.Maui.Controls;
#endif

namespace DemoCenter.Maui {
    public partial class App : Application {

        public App() {
            var culture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();
#if PaidDemoModules
            Routing.RegisterRoute("editFieldsPage", typeof(Views.FillPDFEditFieldsPage));
#endif
            MainPage = new AppShell();
        }
    }
}
