using Ardalis.Result;
using CRM.DAL.Repositories.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.Delete
{
    public class DeleteDealHandler : IRequestHandler<DeleteDealCommand, Result>
    {
        private readonly IDealRepository _dealRepository;

        public DeleteDealHandler(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }

        public async Task<Result> Handle(DeleteDealCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _dealRepository.DeleteAsync(request.Id);
                return Result.Success();
            }
            catch (KeyNotFoundException knf)
            {
                return Result.NotFound(knf.Message);
            }
        }
    }
}