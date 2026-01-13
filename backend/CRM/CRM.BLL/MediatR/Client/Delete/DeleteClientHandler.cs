using Ardalis.Result;
using CRM.DAL.Context;
using CRM.DAL.Repositories.Client;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.Delete
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, Result>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Result> Handle(
            DeleteClientCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _clientRepository.DeleteAsync(request.Id);
                return Result.Success();
            }
            catch (KeyNotFoundException knf)
            {
                return Result.NotFound(knf.Message);
            }
        }
    }
}
