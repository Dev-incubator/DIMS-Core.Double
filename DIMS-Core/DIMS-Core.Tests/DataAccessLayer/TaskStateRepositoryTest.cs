using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using Microsoft.AspNetCore.Mvc.Formatters;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class TaskStateRepositoryTest : IDisposable
    {
        private readonly DIMSCoreContext _dimsCoreContext;
        private readonly TaskStateRepository _repository;

        public TaskStateRepositoryTest()
        {
            _dimsCoreContext = ContextCreator.CreateContext();
            _repository = new TaskStateRepository(_dimsCoreContext);
        }

        [Fact]
        public async Task GetAll()
        {
            var taskStatesSeed = new List<TaskState>()
            {
                new (){ StateId = 1, StateName = "Test"},
                new (){ StateId = 2, StateName = "Test"},
                new (){ StateId = 3, StateName = "Test"},
                new (){ StateId = 4, StateName = "Test"},
                new (){ StateId = 5, StateName = "Test"},
            };
            await _dimsCoreContext.TaskStates.AddRangeAsync(taskStatesSeed);
            await _dimsCoreContext.SaveChangesAsync();

            var repositoryTaskStates = _repository.GetAll();

            Assert.Equal(taskStatesSeed, repositoryTaskStates, new TaskStateEqualityComparer());
        }

        [Fact]
        public async Task Create()
        {
            var taskSateCreate = new TaskState() { StateId = 1, StateName = "Test" };

            await _repository.Create(taskSateCreate);

            var taskState = _dimsCoreContext.TaskStates.First();

            Assert.Equal(taskSateCreate,taskState, new TaskStateEqualityComparer());
        }

        public void Dispose()
        {
            _dimsCoreContext?.Dispose();
        }
    }
}
