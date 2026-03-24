using Entities = CRM.Domain.Entities;

namespace CRM.DAL.Repositories.Deal
{
    public interface IDealRepository : IGenericRepository<Entities.Deal>
    {
        Task<Entities.Deal?> GetByIdWithIncludesAsync(int id);
        Task<List<Entities.Deal>> GetAllWithIncludesAsync();
    }
}