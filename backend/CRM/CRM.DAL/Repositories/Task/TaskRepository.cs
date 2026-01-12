using CRM.DAL.Context;

namespace CRM.DAL.Repositories.Task
{
    public class TaskRepository : GenericRepository<Domain.Entities.Task>, ITaskRepository
    {
        public TaskRepository(CRMDbContext context) : base(context)
        {
        }
    }
}
