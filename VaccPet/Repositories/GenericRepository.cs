using SQLite;

namespace VaccPet.Repositories
{
    public class GenericRepository<T> where T : new()
    {
        private readonly SQLiteAsyncConnection _database;

        public GenericRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<T>().Wait();
        }
       
        public Task<List<T>> GetAllAsync()
        {
            return _database.Table<T>().ToListAsync();
        }

        public Task<int> SaveAsync(T item)
        {
            return _database.InsertAsync(item);
        }

        public Task<int> UpdateAsync(T item)
        {
            return _database.UpdateAsync(item);
        }

        public Task<int> DeleteAsync(T item)
        {
            return _database.DeleteAsync(item);
        }
        
        public Task<int> DeleteAllAsync()
        {
            return _database.DeleteAllAsync<T>();
        }
    }
}
