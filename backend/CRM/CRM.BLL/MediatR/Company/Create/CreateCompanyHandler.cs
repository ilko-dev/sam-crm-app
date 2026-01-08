using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using MediatR;
using Entities = CRM.Domain.Entities;

namespace CRM.BLL.MediatR.Company.Create
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Result<CompanyDTO>>
    {
        private readonly CRMDbContext _context;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(CRMDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<CompanyDTO>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Entities.Company>(request.Dto);

            _context.Companies.Add(company);
            await _context.SaveChangesAsync(cancellationToken);

            var dto = _mapper.Map<CompanyDTO>(company);
            return Result.Success(dto);
        }
    }
}
