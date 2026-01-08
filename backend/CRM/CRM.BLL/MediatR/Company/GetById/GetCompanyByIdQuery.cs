using Ardalis.Result;
using CRM.BLL.DTO.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.GetById
{
    public record GetCompanyByIdQuery(int Id)
     : IRequest<Result<CompanyDTO?>>;
}
