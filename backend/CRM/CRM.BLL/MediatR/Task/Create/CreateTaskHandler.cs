using Ardalis.Result;
using AutoMapper;
using MediatR;
using CRM.DAL.Repositories.Task;
using CRM.BLL.DTO.Task;

namespace CRM.BLL.MediatR.Task.Create
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, Result<TaskDTO>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Result<TaskDTO>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = _mapper.Map<Domain.Entities.Task>(request.Dto);

                await _taskRepository.AddAsync(task);
                var dto = _mapper.Map<TaskDTO>(task);

                return Result.Success(dto);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
