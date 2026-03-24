using Ardalis.Result;
using CRM.BLL.DTO.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.Update
{
    public record UpdateDealCommand(int Id, CreateUpdateDealDTO Dto)
        : IRequest<Result>;
}