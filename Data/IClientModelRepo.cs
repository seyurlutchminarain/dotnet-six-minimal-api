using SixMinApi.Models;

namespace SixMinApi.Data
{
    public interface IClientModelRepo
    {
        Task SaveChanges();
        Task<ClientModel?> GetClientModelById(int id);
        Task<IEnumerable<ClientModel>> GetAllClientModels();
        Task CreateClientModel(ClientModel cmd);

        void DeleteClientModel(ClientModel cmd);
    }
}