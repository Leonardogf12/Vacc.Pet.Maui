using VaccPet.MVVM.Models;

namespace VaccPet.Services
{
    public interface IVaccineService
    {
        Task<int> AddVaccine(VaccineModel model);
        Task<int> DeleteVaccine(VaccineModel model);
        Task DeleteAllVaccines();
        Task<int> UpdateVaccine(VaccineModel model);
        Task<VaccineModel> GetVaccine(int id);
        Task<List<VaccineModel>> GetVaccinesList();
    }
}
