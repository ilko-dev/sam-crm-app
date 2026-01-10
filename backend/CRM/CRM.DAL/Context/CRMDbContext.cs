using CRM.DAL.Configurations;
using CRM.Domain.Entities;
using CRM.Domain.Entities.User;
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
        public DbSet<User> Users => Set<User>();
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CRMDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
