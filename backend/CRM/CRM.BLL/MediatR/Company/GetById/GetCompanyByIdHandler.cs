using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Company;
using CRM.DAL.Repositories.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.GetById
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, Result<CompanyDTO>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanyByIdHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Result<CompanyDTO>> Handle(
            GetCompanyByIdQuery request,
            CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            if (company is null)
                return Result.NotFound("Company not found");

            return Result.Success(_mapper.Map<CompanyDTO>(company));
        }
    }
}
