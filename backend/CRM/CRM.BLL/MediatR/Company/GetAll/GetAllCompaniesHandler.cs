using AutoMapper;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Company.GetAll
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, IEnumerable<CompanyDTO>>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCompaniesHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDTO>> Handle(
            GetAllCompaniesQuery request,
            CancellationToken cancellationToken)
        {
            var companies = await _context.Companies
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<CompanyDTO>>(companies);
        }
    }
}
