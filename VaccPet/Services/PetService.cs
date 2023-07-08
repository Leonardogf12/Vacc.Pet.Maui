using System.Linq.Expressions;
using VaccPet.Data;
using VaccPet.MVVM.Models;

namespace VaccPet.Services
{
    public class PetService : IPetService
    {
        public async Task<int> AddPet(PetModel model)
        {
            return await DBConnection.Instance.Database.InsertAsync(model);
        }

        public async Task<int> DeletePet(PetModel model)
        {
            return await DBConnection.Instance.Database.DeleteAsync(model);
        }

        public async Task<int> UpdatePet(PetModel model)
        {
            return await DBConnection.Instance.Database.UpdateAsync(model);
        }

        public async Task<PetModel> GetPet(int id)
        {
            return await DBConnection.Instance.Database.Table<PetModel>()
                                        .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<PetModel>> GetPetsList()
        {
            return await DBConnection.Instance.Database.Table<PetModel>().ToListAsync();                           
        }

        public async Task DeleteAllPets()
        {
            await DBConnection.Instance.Database.DeleteAllAsync<PetModel>();
        }

        public event EventHandler<PetModel> SelectedPetPublished;

        public void PublishSelectedPet(PetModel pet)
        {
            SelectedPetPublished?.Invoke(this, pet);
        }
    }
}
