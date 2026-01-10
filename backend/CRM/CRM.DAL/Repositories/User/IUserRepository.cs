using UserModel = CRM.Domain.Entities.User.User;

namespace CRM.DAL.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        Task<UserModel?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<UserModel?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<List<UserModel>> GetAllAsync(CancellationToken ct = default);
    }
}
