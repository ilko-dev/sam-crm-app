using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.GetAll
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, Result<IEnumerable<ClientDTO>>>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public GetAllClientsHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ClientDTO>>> Handle(
            GetAllClientsQuery request,
            CancellationToken cancellationToken)
        {
            var clients = await _context.Clients
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var dtos = _mapper.Map<IEnumerable<ClientDTO>>(clients);

            return Result.Success(dtos);
        }
    }
}
