using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ClientModel> ClientModels => Set<ClientModel>();
        public DbSet<AddressModel> AddressModels => Set<AddressModel>();
        public DbSet<BankAccountModel> BankAccountModels => Set<BankAccountModel>();
        public DbSet<BeneficiaryModel> BeneficiaryModels => Set<BeneficiaryModel>();
        public DbSet<DependantModel> DependantModels => Set<DependantModel>();
        
    }
}