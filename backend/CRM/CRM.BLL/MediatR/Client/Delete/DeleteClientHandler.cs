using Ardalis.Result;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Client.Delete
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand, Result>
    {
        private readonly CRMDbContext _context;

        public DeleteClientHandler(CRMDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(
            DeleteClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (client == null)
                return Result.NotFound();

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
