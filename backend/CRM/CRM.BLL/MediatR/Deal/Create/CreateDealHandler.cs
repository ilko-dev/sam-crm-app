using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Deal;
using CRM.DAL.Repositories.Deal;
using MediatR;
using Entities = CRM.Domain.Entities;

namespace CRM.BLL.MediatR.Deal.Create
{
    public class CreateDealHandler : IRequestHandler<CreateDealCommand, Result<DealDTO>>
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;

        public CreateDealHandler(IDealRepository dealRepository, IMapper mapper)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
        }

        public async Task<Result<DealDTO>> Handle(CreateDealCommand request, CancellationToken cancellationToken)
        {
            var deal = new Entities.Deal(
                request.Dto.Title,
                request.Dto.Amount,
                request.Dto.Stage,
                request.Dto.ExpectedCloseDate,
                request.Dto.ClientId,
                request.Dto.AssignedUserId,
                request.Dto.Description
            );

            await _dealRepository.AddAsync(deal);

            var dto = _mapper.Map<DealDTO>(deal);
            return Result.Success(dto);
        }
    }
}