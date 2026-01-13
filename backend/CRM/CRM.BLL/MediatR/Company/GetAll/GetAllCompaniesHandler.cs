using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Company;
using CRM.DAL.Context;
using CRM.DAL.Repositories.Company;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CRM.BLL.MediatR.Company.GetAll
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, Result<IEnumerable<CompanyDTO>>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetAllCompaniesHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CompanyDTO>>> Handle(
            GetAllCompaniesQuery request,
            CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();
            var dtos = _mapper.Map<IEnumerable<CompanyDTO>>(companies);

            return Result.Success(dtos);
        }
    }
}
