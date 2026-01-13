using Ardalis.Result;
using CRM.DAL.Repositories.Company;
using MediatR;

namespace CRM.BLL.MediatR.Company.Delete
{
    public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyCommand, Result>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Result> Handle(
            DeleteCompanyCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                await _companyRepository.DeleteAsync(request.Id);
                return Result.Success();
            }
            catch (KeyNotFoundException knf)
            {
                return Result.NotFound(knf.Message);
            }
        }
    }
}
