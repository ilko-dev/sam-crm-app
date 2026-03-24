using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Deal;
using CRM.DAL.Repositories.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.GetById
{
    public class GetDealByIdHandler : IRequestHandler<GetDealByIdQuery, Result<DealDTO>>
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;

        public GetDealByIdHandler(IDealRepository dealRepository, IMapper mapper)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
        }

        public async Task<Result<DealDTO>> Handle(GetDealByIdQuery request, CancellationToken cancellationToken)
        {
            var deal = await _dealRepository.GetByIdWithIncludesAsync(request.Id);

            if (deal == null)
                return Result.NotFound($"Deal with ID {request.Id} not found");

            var dto = _mapper.Map<DealDTO>(deal);
            return Result.Success(dto);
        }
    }
}