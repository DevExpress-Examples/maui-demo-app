using System;
namespace DemoCenter.Maui.Styles.ThemeLoader {
    internal partial class PlatformThemeLoader {
        static PlatformThemeLoader instance = null;
        public static PlatformThemeLoader Instance {
            get {
                if (instance == null)
                    instance = new PlatformThemeLoader();

                return instance;
            }
        }
        //public PlatformThemeLoader() {
        //}
    }
}

