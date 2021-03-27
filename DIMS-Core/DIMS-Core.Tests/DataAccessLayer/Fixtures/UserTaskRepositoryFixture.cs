using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public class UserTaskRepositoryFixture : BaseRepositoryFixture<UserTaskRepository>
    {
        public int UpdateUserTaskId { get; set; }
        public int DeleteUserTaskId { get; set; }
        public int AddUserTaskId { get; set; }

        protected override UserTaskRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDatabase()
        {
            UpdateUserTaskId = (await Context.UserTasks.AddAsync(new UserTask
            {
                UserId = 1,
                TaskId = 1,
                StateId = 1,
                
            })).Entity.UserTaskId;

            DeleteUserTaskId = (await Context.UserTasks.AddAsync(new UserTask
            {
                UserId = 2,
                TaskId = 2,
                StateId = 2,

            })).Entity.UserTaskId;

            AddUserTaskId = (await Context.UserTasks.AddAsync(new UserTask
            {
                UserId = 3,
                TaskId = 3,
                StateId = 3,

            })).Entity.UserTaskId;

            await Context.SaveChangesAsync();
        }
    }
}
