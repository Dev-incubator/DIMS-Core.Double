using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Models.Enums;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class TaskStateService : Service<TaskStateModel, TaskState, ITaskStateRepository>, ITaskStateService
    {
        public TaskStateService(ITaskStateRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public Task SetState(int userId, int taskId, TaskStateEnum stateEnum)
        {
            return _repository.SetState(userId, taskId, stateEnum);
        }
    }
}
