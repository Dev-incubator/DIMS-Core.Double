using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface ITaskStateService : IService<TaskStateModel>
    {
        Task SetState(int userId, int taskId, TaskStateEnum stateEnum);
    }
}
