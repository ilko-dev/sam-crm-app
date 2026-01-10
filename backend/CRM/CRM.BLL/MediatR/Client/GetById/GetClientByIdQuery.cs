using Ardalis.Result;
using CRM.BLL.DTO.Client;
using MediatR;

namespace CRM.BLL.MediatR.Client.GetById
{
    public record GetClientByIdQuery(int Id)
     : IRequest<Result<ClientDTO>>;
}
