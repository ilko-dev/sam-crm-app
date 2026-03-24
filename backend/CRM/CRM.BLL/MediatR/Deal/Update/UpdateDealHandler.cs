using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Deal;
using CRM.DAL.Repositories.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.Update
{
    public class UpdateDealHandler : IRequestHandler<UpdateDealCommand, Result>
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;

        public UpdateDealHandler(IDealRepository dealRepository, IMapper mapper)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateDealCommand request, CancellationToken cancellationToken)
        {
            var deal = await _dealRepository.GetAsync(request.Id);
            if (deal == null)
                return Result.NotFound($"Deal with ID {request.Id} not found");

            _mapper.Map(request.Dto, deal);
            await _dealRepository.UpdateAsync(deal);
            return Result.Success();
        }
    }
}