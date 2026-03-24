using Ardalis.Result;
using CRM.BLL.DTO.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.Create
{
    public record CreateDealCommand(CreateUpdateDealDTO Dto)
        : IRequest<Result<DealDTO>>;
}