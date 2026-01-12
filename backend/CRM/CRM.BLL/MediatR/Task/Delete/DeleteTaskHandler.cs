using Ardalis.Result;
using AutoMapper;
using CRM.BLL.DTO.Task;
using CRM.BLL.MediatR.Client.Delete;
using CRM.DAL.Repositories.Task;
using MediatR;

namespace CRM.BLL.MediatR.Task.Delete
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, Result>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public DeleteTaskHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _taskRepository.DeleteAsync(request.Id);
                return Result.Success();
            }
            catch (KeyNotFoundException knf)
            {
                return Result.NotFound(knf.Message);
            }
            catch (Exception ex)
            {
                return Result.Error($"Failed to delete task: {ex.Message}");
            }
        }
    }
}
