using Ardalis.Result;
using CRM.BLL.DTO.Client;
using MediatR;

namespace CRM.BLL.MediatR.Client.Update
{
    public record UpdateClientCommand(Guid Id, CreateUpdateClientDTO Dto)
    : IRequest<Result>;
}
