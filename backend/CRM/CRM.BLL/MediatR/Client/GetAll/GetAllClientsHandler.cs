using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using CRM.DAL.Repositories.Client;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.GetAll
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, Result<IEnumerable<ClientDTO>>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetAllClientsHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ClientDTO>>> Handle(
            GetAllClientsQuery request,
            CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<ClientDTO>>(clients);

            return Result.Success(dtos);
        }
    }
}
