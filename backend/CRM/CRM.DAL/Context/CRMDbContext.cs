using CRM.DAL.Configurations;
using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL.Context
{
    public class CRMDbContext : DbContext
    {
        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Client> Clients => Set<Client>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
