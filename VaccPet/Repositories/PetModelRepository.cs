using SQLite;
using VaccPet.MVVM.Models;

namespace VaccPet.Repositories
{
    public class PetModelRepository
    {
        private readonly GenericRepository<PetModel> _genericRepository;

        private readonly SQLiteAsyncConnection _dataBase;

        public PetModelRepository(string dbPath)
        {
            _genericRepository = new GenericRepository<PetModel>(dbPath);
            _dataBase = new SQLiteAsyncConnection(dbPath);
        }

        public Task<List<PetModel>> GetAllPetsAsync()
        {
            return _genericRepository.GetAllAsync();
        }

        public Task<int> SavePetAsync(PetModel model)
        {
            return _genericRepository.SaveAsync(model);
        }

        public Task<int> UpdatePetAsync(PetModel model)
        {
            return _genericRepository.UpdateAsync(model);
        }

        public Task<int> DeletePetAsync(PetModel model)
        {
            return _genericRepository.DeleteAsync(model);
        }

        public Task<int> DeleteAllAsync()
        {
            return _genericRepository.DeleteAllAsync();
        }

        public async Task<PetModel> GetPetByIdAsync(int id)
        {
            return await _dataBase.Table<PetModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
