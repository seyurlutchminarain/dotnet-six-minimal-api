using SixMinApi.Models;

namespace SixMinApi.Data
{
    public interface IDependantModelRepo
    {
        Task SaveChanges();

        Task<DependantModel?> GetDependantById(int id);

        Task<IEnumerable<DependantModel>> GetAllDependants();

        Task CreateDependantModel(DependantModel dependant);

        void DeleteDependant(DependantModel dependant);
    }
}