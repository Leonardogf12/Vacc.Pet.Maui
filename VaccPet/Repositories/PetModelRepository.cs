using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccPet.MVVM.Models;

namespace VaccPet.Repositories
{
    public class PetModelRepository
    {
        private readonly GenericRepository<PetModel> _genericRepository;

        public PetModelRepository(string dbPath)
        {
            _genericRepository = new GenericRepository<PetModel>(dbPath);
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

    }
}
