using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Task;
using CRM.DAL.Repositories.Task;
using MediatR;

namespace CRM.BLL.MediatR.Task.GetAll
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, Result<IEnumerable<TaskDTO>>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetAllTasksHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<TaskDTO>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync();

            var dtos = _mapper.Map<List<TaskDTO>>(tasks);
            return Result.Success<IEnumerable<TaskDTO>>(dtos);
        }
    }
}
