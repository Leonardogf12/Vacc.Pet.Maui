using SQLite;
using VaccPet.MVVM.Models;

namespace VaccPet.Data
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PetModel>();
            _database.CreateTableAsync<VaccineModel>();
        }
    }
}
