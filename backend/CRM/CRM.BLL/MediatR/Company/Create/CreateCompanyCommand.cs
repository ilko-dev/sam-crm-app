using CRM.BLL.DTO.Company;
using MediatR; 

namespace CRM.BLL.MediatR.Company.Create
{
    public record CreateCompanyCommand(CreateUpdateCompanyDTO Dto)
        : IRequest<CompanyDTO>;
}
