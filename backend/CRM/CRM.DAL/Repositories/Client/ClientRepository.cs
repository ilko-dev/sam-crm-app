using CRM.DAL.Context;

namespace CRM.DAL.Repositories.Client
{
    public class ClientRepository : GenericRepository<Domain.Entities.Client>, IClientRepository
    {
        public ClientRepository(CRMDbContext context) : base(context)
        {
        }
    }
}
