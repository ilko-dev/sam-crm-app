using AutoMapper;
using CRM.BLL.DTO.Task;
using CRM.Domain.Entities;
using Task = CRM.Domain.Entities.Task;

namespace CRM.BLL.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDTO>().ReverseMap();
            CreateMap<CreateUpdateTaskDTO, Task>().ReverseMap();
        }
    }
}
