using CRM.DAL.Context;
using CRM.DAL.Repositories.Deal;
using Entities = CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL.Repositories.Deal
{
    public class DealRepository : GenericRepository<Entities.Deal>, IDealRepository
    {
        private readonly CRMDbContext _context;

        public DealRepository(CRMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Entities.Deal?> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Deals
                .Include(d => d.Client)
                .Include(d => d.AssignedUser)
                .ThenInclude(u => u.Profile)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Entities.Deal>> GetAllWithIncludesAsync()
        {
            return await _context.Deals
                .Include(d => d.Client)
                .Include(d => d.AssignedUser)
                .ThenInclude(u => u.Profile)
                .ToListAsync();
        }
    }
}