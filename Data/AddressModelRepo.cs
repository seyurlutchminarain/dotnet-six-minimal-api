using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class AddressModelRepo : IAddressModelRepo
    {
        private readonly AppDbContext _context;

        public AddressModelRepo(AppDbContext context)
        {
            _context = context;    
        }

        public async Task CreateAddressModel(AddressModel address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            await _context.AddAsync(address);
        }

        public void DeleteAddress(AddressModel address)
        {
            if(address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            _context.AddressModels.Remove(address);
        }

        public async Task<AddressModel?> GetAddressById(int id)
        {
            return await _context.AddressModels.FirstOrDefaultAsync(x => x.AddressId == id);
        }

        public async Task<IEnumerable<AddressModel>> GetAllAddresses()
        {
            return await _context.AddressModels.ToListAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}