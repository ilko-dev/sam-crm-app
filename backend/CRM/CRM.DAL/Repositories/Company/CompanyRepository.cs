using CRM.DAL.Context;
using Entities = CRM.Domain.Entities;

namespace CRM.DAL.Repositories.Company
{
    public class CompanyRepository : GenericRepository<Entities.Company>, ICompanyRepository
    {
        public CompanyRepository(CRMDbContext context) : base(context)
        {
        }
    }
}
