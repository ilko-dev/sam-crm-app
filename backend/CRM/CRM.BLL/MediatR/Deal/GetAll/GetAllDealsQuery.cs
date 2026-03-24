using Ardalis.Result;
using CRM.BLL.DTO.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.GetAll
{
    public record GetAllDealsQuery()
        : IRequest<Result<IEnumerable<DealDTO>>>;
}