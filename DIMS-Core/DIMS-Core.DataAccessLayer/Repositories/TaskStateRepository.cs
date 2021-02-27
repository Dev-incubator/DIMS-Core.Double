using System;
using DIMS_Core.Common.Extensions;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskStateRepository : Repository<TaskState>, ITaskStateRepository
    {
        public TaskStateRepository(DbContext context) : base(context)
        {
        }

        public Task SetState(int userId, int taskId, TaskStateEnum stateEnum)
        {
            return stateEnum switch
            {
                TaskStateEnum.Success => _set.FromSqlInterpolated($"EXEC SetUserTaskAsSuccess {userId}, {taskId}").ToListAsync(),
                TaskStateEnum.Fail => _set.FromSqlInterpolated($"EXEC SetUserTaskAsFail {taskId}, {taskId}").ToListAsync(),
                _ => Task.CompletedTask
            };
        }
    }
}
