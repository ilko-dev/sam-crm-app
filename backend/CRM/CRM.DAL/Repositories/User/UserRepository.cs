using CRM.DAL.Context;
using Microsoft.EntityFrameworkCore;
using UserModel = CRM.Domain.Entities.User.User;

namespace CRM.DAL.Repositories.User
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
        private readonly CRMDbContext _context;

        public UserRepository(CRMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAllAsync(CancellationToken ct = default)
        {
            return await _context.Users
                .Include(u => u.Profile)
                .ToListAsync(ct);
        }

        public async Task<UserModel?> GetByEmailAsync(string email, CancellationToken ct = default)
        {
            return await _context.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Email == email, ct);
        }

        public async Task<UserModel?> GetByIdAsync(int id, CancellationToken ct = default)
        {
           return await _context.Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(u => u.Id == id, ct);
        }
    }
}
