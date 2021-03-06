using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure.Comparer;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class TaskStateRepositoryTest : IDisposable
    {
        private readonly RepositoryTestHelper<TaskState> _repositoryTestHelper;
        private DIMSCoreContext _context;

        private readonly List<TaskState> _seedTaskStates = new()
        {
            new() { StateName = "Test1" },
            new() { StateName = "Test2" },
            new() { StateName = "Test3" },
            new() { StateName = "Test4" }
        };

        public TaskStateRepositoryTest()
        {
            var context = ContextCreator.CreateContext();
            _repositoryTestHelper = new RepositoryTestHelper<TaskState>(context, new TaskStateRepository(context),
                                                            (entity) => ValueTuple.Create(entity.StateName));
        }

        [Fact]
        public Task GetAll()
        {
            return _repositoryTestHelper.GetAllEqualsSeedData(_seedTaskStates);
        }

        [Fact]
        public Task GetById()
        {
            return _repositoryTestHelper.GetByIdEqualsSeedEntity(_seedTaskStates.First());
        }

        [Fact]
        public Task Create()
        {
            return _repositoryTestHelper.CreatedEntityEqualsSeedEntity(_seedTaskStates.First());
        }

        [Fact]
        public Task Update()
        {
            return _repositoryTestHelper.IsEntityUpdated(new TaskState() { StateName = "Start" },
                                                   (entity) =>
                                                   {
                                                       entity.StateName = "Updated";
                                                       return entity;
                                                   });
        }

        [Fact]
        public Task Delete()
        {
            return _repositoryTestHelper.HasEntityDeleted(_seedTaskStates.First());
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
