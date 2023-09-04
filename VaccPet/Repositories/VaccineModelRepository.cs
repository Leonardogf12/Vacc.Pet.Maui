using SQLite;
using VaccPet.MVVM.Models;

namespace VaccPet.Repositories
{
    public class VaccineModelRepository
    {
        private readonly GenericRepository<VaccineModel> _genericRepository;
        private readonly SQLiteAsyncConnection _database;

        public VaccineModelRepository(string dbPath)
        {
            _genericRepository = new GenericRepository<VaccineModel>(dbPath);
            _database = new SQLiteAsyncConnection(dbPath);
        }

        public Task<List<VaccineModel>> GetAllVaccinesAsync()
        {
            return _genericRepository.GetAllAsync();
        }

        public Task<int> SaveVaccineAsync(VaccineModel model)
        {
            return _genericRepository.SaveAsync(model);
        }

        public Task<int> UpdateVaccineAsync(VaccineModel model)
        {
            return _genericRepository.UpdateAsync(model);
        }

        public Task<int> DeleteVaccineAsync(VaccineModel model)
        {
            return _genericRepository.DeleteAsync(model);
        }

        public Task<int> DeleteAllAsync()
        {
            return _genericRepository.DeleteAllAsync();
        }

        public Task<List<VaccineModel>> GetAllVaccinesByPetAsync(int idPet)
        {
            return _database.Table<VaccineModel>().Where(x => x.PetlId == idPet).OrderByDescending(x => x.VaccinationDate).ToListAsync();
        }
    }
}
