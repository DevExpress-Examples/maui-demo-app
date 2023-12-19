namespace DemoCenter.Maui.Styles.ThemeLoader {
    internal sealed partial class PlatformThemeLoader {
        static PlatformThemeLoader instance;
        public static PlatformThemeLoader Instance {
            get {
                if (instance == null)
                    instance = new PlatformThemeLoader();

                return instance;
            }
        }
    }
}

