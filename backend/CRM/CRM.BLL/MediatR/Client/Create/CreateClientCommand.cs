using Ardalis.Result;
using CRM.BLL.DTO.Client;
using MediatR; 

namespace CRM.BLL.MediatR.Client.Create
{
    public record CreateClientCommand(CreateUpdateClientDTO Dto)
        : IRequest<Result<ClientDTO>>;
}
