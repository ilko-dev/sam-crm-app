using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Deal;
using CRM.DAL.Repositories.Deal;
using MediatR;

namespace CRM.BLL.MediatR.Deal.GetAll
{
    public class GetAllDealsHandler : IRequestHandler<GetAllDealsQuery, Result<IEnumerable<DealDTO>>>
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;

        public GetAllDealsHandler(IDealRepository dealRepository, IMapper mapper)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<DealDTO>>> Handle(GetAllDealsQuery request, CancellationToken cancellationToken)
        {
            var deals = await _dealRepository.GetAllWithIncludesAsync();
            var dtos = _mapper.Map<IEnumerable<DealDTO>>(deals);
            return Result.Success(dtos);
        }
    }
}