using Ardalis.Result;
using CRM.BLL.DTO.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.Update
{
    public record UpdateCompanyCommand(int Id, CreateUpdateCompanyDTO Dto)
    : IRequest<Result>;
}
