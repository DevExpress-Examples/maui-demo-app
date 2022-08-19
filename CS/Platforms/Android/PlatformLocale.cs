using System.Globalization;

namespace DemoCenter.Maui {
    public partial class PlatformLocale {
        public partial string GetPlatformLocale() {
            return CultureInfo.CurrentCulture.Name;
        }
    }
}

