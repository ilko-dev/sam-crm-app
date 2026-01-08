using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using MediatR;
using Entities = CRM.Domain.Entities;

namespace CRM.BLL.MediatR.Client.Create
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, Result<ClientDTO>>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public CreateClientHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ClientDTO>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = _mapper.Map<Entities.Client>(request.Dto);

            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<ClientDTO>(client);
            return Result.Success(dto);
        }
    }
}
