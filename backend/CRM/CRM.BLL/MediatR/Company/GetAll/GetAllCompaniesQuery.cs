using CRM.BLL.DTO.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.GetAll
{
    public record GetAllCompaniesQuery()
    : IRequest<IEnumerable<CompanyDTO>>;
}
