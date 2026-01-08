using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Client;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.GetById
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Result<ClientDTO>>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public GetClientByIdHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ClientDTO>> Handle(
            GetClientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (client is null)
                return Result.NotFound("Client not found");

            return Result.Success(_mapper.Map<ClientDTO>(client));
        }
    }
}
