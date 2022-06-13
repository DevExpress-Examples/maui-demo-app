using Foundation;
namespace DemoCenter.Maui {
    public partial class PlatformLocale {
        public partial string GetPlatformLocale() {
            return NSLocale.PreferredLanguages[0];
        }
    }
}

