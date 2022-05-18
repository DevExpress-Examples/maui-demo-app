using SQLite;

namespace DemoCenter.Maui.ViewModels {
    public abstract class ItemRepository<T> where T : DataItem {
        readonly SQLiteConnection database;

        protected SQLiteConnection DataBase => database;

        protected ItemRepository(string databasePath) {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<T>();
        }

        public int DeleteItem(int id) {
            return database.Delete<T>(id);
        }
        public int SaveItem(T item) {
            if (item.Id == 0)
                return database.Insert(item);
            database.Update(item);
            return item.Id;
        }
    }
}
