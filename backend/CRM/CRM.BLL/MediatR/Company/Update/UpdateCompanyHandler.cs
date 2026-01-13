using Ardalis.Result;
using AutoMapper;
using CRM.DAL.Repositories.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.Update
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, Result>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public UpdateCompanyHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(
            UpdateCompanyCommand request,
            CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetAsync(request.Id);

            if (company == null)
            {
                return Result.NotFound($"Company with Id {request.Id} not found.");
            }

            _mapper.Map(request.Dto, company);

            await _companyRepository.UpdateAsync(company);
            return Result.Success();
        }
    }
}
