using SixMinApi.Models;

namespace SixMinApi.Data
{
    public interface IBankingModelRepo
    {
        Task SaveChanges();

        Task<BankAccountModel?> GetBankAccountById(int id);

        Task<IEnumerable<BankAccountModel>> GetAllBankAccounts();

        Task CreateBankAccountModel(BankAccountModel bankAccount);

        void DeleteBankAccount(BankAccountModel bankAccountModel);

    }
}