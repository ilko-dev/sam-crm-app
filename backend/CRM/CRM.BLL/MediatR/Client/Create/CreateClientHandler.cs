using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using CRM.DAL.Repositories.Client;
using MediatR;
using Entities = CRM.Domain.Entities;

namespace CRM.BLL.MediatR.Client.Create
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Result<ClientDTO>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public CreateClientHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Result<ClientDTO>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Entities.Client>(request.Dto);
            await _clientRepository.AddAsync(client);

            var dto = _mapper.Map<ClientDTO>(client);
            return Result.Success(dto);
        }
    }
}
