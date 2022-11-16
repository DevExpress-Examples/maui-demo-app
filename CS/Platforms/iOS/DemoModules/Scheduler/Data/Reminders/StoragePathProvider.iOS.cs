using System;
using System.IO;
using Foundation;

namespace DemoCenter.Maui.DemoModules.Scheduler.Data.Reminders {
    public partial class StoragePathProvider : NSObject {
            public string GetPath(string fileName) {
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string libraryPath = Path.Combine(documentsPath, "..", "Library");
                return Path.Combine(libraryPath, fileName);
            }
        }
    }