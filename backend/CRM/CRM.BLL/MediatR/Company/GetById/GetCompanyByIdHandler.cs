using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Company.GetById
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, Result<CompanyDTO>>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyByIdHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CompanyDTO>> Handle(
            GetCompanyByIdQuery request,
            CancellationToken cancellationToken)
        {
            var company = await _context.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (company is null)
                return Result.NotFound("Company not found");

            return Result.Success(_mapper.Map<CompanyDTO>(company));
        }
    }
}
