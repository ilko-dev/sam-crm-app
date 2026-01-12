using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Task;
using CRM.DAL.Repositories.Task;
using MediatR;

namespace CRM.BLL.MediatR.Task.GetById
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, Result<TaskDTO>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskByIdHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<Result<TaskDTO>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetAsync(request.Id);

                if (task is null)
                    return Result.NotFound("Task not found");

                return Result.Success(_mapper.Map<TaskDTO>(task));
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
