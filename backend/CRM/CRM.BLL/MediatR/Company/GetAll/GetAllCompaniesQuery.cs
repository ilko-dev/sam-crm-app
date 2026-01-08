using Ardalis.Result;
using CRM.BLL.DTO.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.GetAll
{
    public record GetAllCompaniesQuery()
    : IRequest<Result<IEnumerable<CompanyDTO>>>;
}
