using VaccPet.Data;
using VaccPet.MVVM.Models;

namespace VaccPet.Services
{
    public class VaccineService : IVaccineService
    {
        public async Task<int> AddVaccine(VaccineModel model)
        {
            return await DBConnection.Instance.Database.InsertAsync(model);
        }

        public async Task DeleteAllVaccines()
        {
            await DBConnection.Instance.Database.DeleteAllAsync<VaccineModel>();
        }

        public async Task<int> DeleteVaccine(VaccineModel model)
        {
            return await DBConnection.Instance.Database.DeleteAsync(model);
        }

        public async Task<VaccineModel> GetVaccine(int id)
        {
            return await DBConnection.Instance.Database.Table<VaccineModel>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<VaccineModel>> GetVaccinesList()
        {
            return await DBConnection.Instance.Database.Table<VaccineModel>().ToListAsync();
        }

        public async Task<int> UpdateVaccine(VaccineModel model)
        {
            return await DBConnection.Instance.Database.UpdateAsync(model);
        }
    }
}
