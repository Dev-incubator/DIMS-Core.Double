using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure.Comparers;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class TaskStateRepositoryTest : IDisposable
    {
        private readonly RepositoryTest<TaskState> _repositoryTest;
        private DIMSCoreContext _context;

        private readonly List<TaskState> _seedTaskStates = new List<TaskState>()
        {
            new() { StateName = "Test1" },
            new() { StateName = "Test2" },
            new() { StateName = "Test3" },
            new() { StateName = "Test4" }
        };

        public TaskStateRepositoryTest()
        {
            var context = ContextCreator.CreateContext();
            _repositoryTest = new RepositoryTest<TaskState>(context, new TaskStateRepository(context), new TaskStateEqualityComparer());
        }

        [Fact]
        public Task GetAll()
        {
            return _repositoryTest.GetAllEqualsSeedData(_seedTaskStates);
        }

        [Fact]
        public Task GetById()
        {
            return _repositoryTest.GetByIdEqualsSeedEntity(_seedTaskStates.First());
        }

        [Fact]
        public Task Create()
        {
            return _repositoryTest.CreateEqualsSeedEntity(_seedTaskStates.First());
        }

        [Fact]
        public Task Update()
        {
            return _repositoryTest.IsEntityUpdated(new TaskState() { StateName = "Start" },
                                                   (entity) =>
                                                   {
                                                       entity.StateName = "Updated";
                                                       return entity;
                                                   });
        }

        [Fact]
        public Task Delete()
        {
            return _repositoryTest.HasEntityDeleted(_seedTaskStates.First());
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
