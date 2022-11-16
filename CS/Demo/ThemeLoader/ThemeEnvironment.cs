using System;

namespace DemoCenter.Maui.Demo.ThemeLoader {
    internal partial class ThemeEnvironment {
        static ThemeEnvironment instance = null;
        public static ThemeEnvironment Instance {
            get {
                if (instance == null)
                    instance = new ThemeEnvironment();

                return instance;
            }
        }
    }
}

