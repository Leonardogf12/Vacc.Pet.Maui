using VaccPet.MVVM.Models;

namespace VaccPet.Services
{
    public interface IPetService
    {
        Task<int> AddPet(PetModel model);
        Task<int> DeletePet(PetModel model);
        Task DeleteAllPets();
        Task<int> UpdatePet(PetModel model);
        Task<PetModel> GetPet(int id);
        Task<List<PetModel>> GetPetsList();


        //Tests
        void PublishSelectedPet(PetModel pet);
        event EventHandler<PetModel> SelectedPetPublished;
    }
}
