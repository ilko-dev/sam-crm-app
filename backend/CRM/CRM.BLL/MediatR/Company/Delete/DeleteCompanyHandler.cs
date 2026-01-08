using Ardalis.Result;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.MediatR.Company.Delete
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Result>
    {
        private readonly CRMDbContext _context;

        public DeleteCompanyHandler(CRMDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(
            DeleteCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var company = await _context.Companies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (company == null)
                return Result.NotFound();

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
