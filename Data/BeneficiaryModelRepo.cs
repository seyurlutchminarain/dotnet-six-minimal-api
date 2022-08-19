using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class BeneficiaryModelRepo : IBeneficiaryModelRepo
    {
        private readonly AppDbContext _context;

        public BeneficiaryModelRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateBeneficiaryModel(BeneficiaryModel beneficiary)
        {
            if (beneficiary == null)
            {
                throw new ArgumentNullException(nameof(beneficiary));
            }

            await _context.AddAsync(beneficiary);
        }

        public void DeleteBeneficaryModel(BeneficiaryModel beneficiary)
        {
            if (beneficiary == null)
            {
                throw new ArgumentNullException(nameof(beneficiary));
            }

            _context.BeneficiaryModels.Remove(beneficiary);
        }

        public async Task<IEnumerable<BeneficiaryModel>> GetAllBeneficiaryModels()
        {
            return await _context.BeneficiaryModels.ToListAsync();
        }

        public async Task<BeneficiaryModel?> GetBeneficiaryModelById(int id)
        {
            return await _context.BeneficiaryModels.FirstOrDefaultAsync(x => x.DependantId == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}