using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Storage;
using SQLite;

namespace DemoCenter.Maui.DemoModules.CollectionView.Data;

public class DBContactService {
    public static DBContactService Instance {
        get;
        set;
    }

    string DBPath;

    public DBContactService(string dbPath) {
        this.DBPath = dbPath;
    }

    public IEnumerable<Contact> GetItems() {
        var conn = new SQLiteConnection(this.DBPath,
            SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone | SQLite.SQLiteOpenFlags.SharedCache |
            SQLiteOpenFlags.FullMutex);
        return conn.Table<Contact>().ToList();
    }

    public void InsertRecord(object item) {
        CreateConnection().Insert(item);
    }

    public void UpdateRecord(object item) {
        CreateConnection().Update(item);
    }

    public void DeleteRecord(object item) {
        CreateConnection().Delete(item);
    }

    SQLiteConnection CreateConnection() {
        return new SQLiteConnection(this.DBPath,
            SQLite.SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.ProtectionNone | SQLite.SQLiteOpenFlags.SharedCache |
            SQLiteOpenFlags.FullMutex);
    }

    public void InitCache() {
        if (!File.Exists(this.DBPath)) {
#if IOS
            File.Copy("DemoModules/CollectionView/Data/contacts.db", this.DBPath);
#else
            var file = File.Create(this.DBPath);
            var task = FileSystem.Current.OpenAppPackageFileAsync("DemoModules/CollectionView/Data/contacts.db");
            task.Wait();
            var fileStream = task.Result;
            fileStream.CopyTo(file);
            fileStream.Close();
            file.Close();
#endif
        }
    }
}