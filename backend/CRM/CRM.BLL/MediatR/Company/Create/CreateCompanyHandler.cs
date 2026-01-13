using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using CRM.DAL.Repositories.Company;
using MediatR;
using Entities = CRM.Domain.Entities;

namespace CRM.BLL.MediatR.Company.Create
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, Result<CompanyDTO>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Result<CompanyDTO>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Entities.Company>(request.Dto);
            await _companyRepository.AddAsync(company);

            var dto = _mapper.Map<CompanyDTO>(company);
            return Result.Success(dto);
        }
    }
}
