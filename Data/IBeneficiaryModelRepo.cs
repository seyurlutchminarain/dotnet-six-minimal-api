using SixMinApi.Models;

namespace SixMinApi.Data
{
    public interface IBeneficiaryModelRepo
    {
        Task SaveChanges();
        Task<BeneficiaryModel?> GetBeneficiaryModelById(int id);
        Task<IEnumerable<BeneficiaryModel>> GetAllBeneficiaryModels();
        Task CreateBeneficiaryModel(BeneficiaryModel beneficiary);

        void DeleteBeneficaryModel(BeneficiaryModel beneficiary);

    }
}