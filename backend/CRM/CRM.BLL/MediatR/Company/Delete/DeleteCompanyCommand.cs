using MediatR;

namespace CRM.BLL.MediatR.Company.Delete
{
    public record DeleteCompanyCommand(int Id)
    : IRequest<bool>;
}
