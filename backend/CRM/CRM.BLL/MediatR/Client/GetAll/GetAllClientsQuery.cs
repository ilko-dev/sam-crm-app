using Ardalis.Result;
using CRM.BLL.DTO.Client;
using MediatR;

namespace CRM.BLL.MediatR.Client.GetAll
{
    public record GetAllClientsQuery()
    : IRequest<Result<IEnumerable<ClientDTO>>>;
}
