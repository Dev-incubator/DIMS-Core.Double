using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Models.Enums;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface ITaskStateRepository : IRepository<TaskState>
    {
        Task SetState(int userId, int taskId, TaskStateEnum stateEnum);
    }
}

