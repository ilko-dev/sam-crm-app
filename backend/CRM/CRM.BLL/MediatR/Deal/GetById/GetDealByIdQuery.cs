using Ardalis.Result;
using CRM.BLL.DTO.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.GetById
{
    public record GetDealByIdQuery(int Id)
        : IRequest<Result<DealDTO>>;
}