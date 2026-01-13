using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.DAL.Context;
using CRM.DAL.Repositories.Client;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.GetById
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Result<ClientDTO>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientByIdHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Result<ClientDTO>> Handle(
            GetClientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAsync(request.Id);

            if (client is null)
                return Result.NotFound("Client not found");

            return Result.Success(_mapper.Map<ClientDTO>(client));
        }
    }
}
