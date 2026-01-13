using Ardalis.Result;
using AutoMapper;
using CRM.DAL.Repositories.Client;
using MediatR;

namespace CRM.BLL.MediatR.Client.Update
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Result>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public UpdateClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.Id);

            if (client == null)
            {
                return Result.NotFound($"Client with Id {request.Id} not found.");
            }

            _mapper.Map(request.Dto, client);

            await _clientRepository.UpdateAsync(client);
            return Result.Success();
        }
    }
}
