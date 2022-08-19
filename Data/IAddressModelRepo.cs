using SixMinApi.Models;

namespace SixMinApi.Data
{
    public interface IAddressModelRepo
    {
        Task SaveChanges();

        Task<AddressModel?> GetAddressById(int id);

        Task<IEnumerable<AddressModel>> GetAllAddresses();

        Task CreateAddressModel(AddressModel address);

        void DeleteAddress(AddressModel address);
    }

}