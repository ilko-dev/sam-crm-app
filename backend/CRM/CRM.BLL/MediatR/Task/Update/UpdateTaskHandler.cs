using Ardalis.Result;
using AutoMapper;
using CRM.BLL.MediatR.Client.Update;
using CRM.DAL.Repositories.Task;
using MediatR;

namespace CRM.BLL.MediatR.Task.Update
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, Result>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public UpdateTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetAsync(request.Id);

                if (task == null)
                {
                    return Result.NotFound($"Task with Id {request.Id} not found.");
                }

                _mapper.Map(request.Dto, task);

                await _taskRepository.UpdateAsync(task);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }

        }
    }
}
