using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class ClientModelRepo : IClientModelRepo
    {
        private readonly AppDbContext _context;

        public ClientModelRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateClientModel(ClientModel cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            await _context.AddAsync(cmd);
        }

        public void DeleteClientModel(ClientModel cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.ClientModels.Remove(cmd);
        }

        public async Task<IEnumerable<ClientModel>> GetAllClientModels()
        {
            return await _context.ClientModels.ToListAsync();
        }

        public async Task<ClientModel?> GetClientModelById(int id)
        {
            return await _context.ClientModels.FirstOrDefaultAsync(c => c.UserId == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}