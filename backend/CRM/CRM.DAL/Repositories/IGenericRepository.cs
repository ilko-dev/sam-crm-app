namespace CRM.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        System.Threading.Tasks.Task DeleteAsync(int? id);
        System.Threading.Tasks.Task UpdateAsync(T entity);
        Task<bool> Exists(int id);
    }
}
