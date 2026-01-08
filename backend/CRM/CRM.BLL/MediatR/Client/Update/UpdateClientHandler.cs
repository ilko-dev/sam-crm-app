using Ardalis.Result;
using AutoMapper;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.Update
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand, Result>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public UpdateClientHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (client == null)
                return Result.NotFound();

            _mapper.Map(request.Dto, client);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
