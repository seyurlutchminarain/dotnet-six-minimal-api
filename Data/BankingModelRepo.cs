using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class BankingModelRepo : IBankingModelRepo
    {
        private readonly AppDbContext _context;

        public BankingModelRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBankAccountModel(BankAccountModel bankAccount)
        {
            if (bankAccount == null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }

            await _context.AddAsync(bankAccount);
        }

        public void DeleteBankAccount(BankAccountModel bankAccountModel)
        {
            if (bankAccountModel == null)
            {
                throw new ArgumentNullException(nameof(bankAccountModel));
            }

            _context.BankAccountModels.Remove(bankAccountModel);
        }

        public async Task<IEnumerable<BankAccountModel>> GetAllBankAccounts()
        {
            return await _context.BankAccountModels.ToListAsync();
        }

        public async Task<BankAccountModel?> GetBankAccountById(int id)
        {
            return await _context.BankAccountModels.FirstOrDefaultAsync(x => x.BankId == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}