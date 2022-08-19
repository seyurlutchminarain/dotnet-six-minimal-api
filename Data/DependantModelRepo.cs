using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class DependantModelRepo : IDependantModelRepo
    {
        private readonly AppDbContext _context;

        public DependantModelRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateDependantModel(DependantModel dependant)
        {
            if (dependant == null)
            {
                throw new ArgumentNullException(nameof(dependant));
            }

             await _context.AddAsync(dependant);
        }

        public void DeleteDependant(DependantModel dependant)
        {
            if (dependant == null)
            {
                throw new ArgumentNullException(nameof(dependant));
            }

            _context.DependantModels.Remove(dependant);
        }

        public async Task<IEnumerable<DependantModel>> GetAllDependants()
        {
            return await _context.DependantModels.ToListAsync();
        }

        public async Task<DependantModel?> GetDependantById(int id)
        {
            return await _context.DependantModels.FirstOrDefaultAsync(x => x.DependantId == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}