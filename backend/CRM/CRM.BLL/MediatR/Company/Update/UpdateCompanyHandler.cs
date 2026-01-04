using AutoMapper;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Company.Update
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Handle(
            UpdateCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var company = await _context.Companies
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (company == null)
                return false;

            _mapper.Map(request.Dto, company);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
