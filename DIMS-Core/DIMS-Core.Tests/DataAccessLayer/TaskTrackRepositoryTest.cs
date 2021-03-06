using System;
using System.Collections.Generic;
using System.Linq;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class TaskTrackRepositoryTest : IDisposable
    {
        private readonly RepositoryTestHelper<TaskTrack> _repositoryTestHelper;
        private readonly DIMSCoreContext _context;

        private readonly List<TaskTrack> _seedTaskTracks = new()
        {
            new() { TrackDate = DateTime.Now.AddDays(1), TrackNote = "Test1" },
            new() { TrackDate = DateTime.Now.AddDays(2), TrackNote = "Test2" },
            new() { TrackDate = DateTime.Now.AddDays(3), TrackNote = "Test3" },
            new() { TrackDate = DateTime.Now.AddDays(4), TrackNote = "Test4" },
            new() { TrackDate = DateTime.Now.AddDays(5), TrackNote = "Test5" },
        };

        public TaskTrackRepositoryTest()
        {
            _context = ContextCreator.CreateContext();
            var repository = new TaskTrackRepository(_context);
            _repositoryTestHelper = new RepositoryTestHelper<TaskTrack>(_context, repository, entity => (entity.TrackDate, entity.TrackNote));
        }

        [Fact]
        public Task GetAll()
        {
            return _repositoryTestHelper.GetAllEqualsSeedData(_seedTaskTracks);
        }

        [Fact]
        public Task GetById()
        {
            return _repositoryTestHelper.GetByIdEqualsSeedEntity(_seedTaskTracks.First());
        }

        [Fact]
        public Task Create()
        {
            return _repositoryTestHelper.CreatedEntityEqualsSeedEntity(_seedTaskTracks.First());
        }

        [Fact]
        public Task Update()
        {
            return _repositoryTestHelper.IsEntityUpdated(_seedTaskTracks.First(), track =>
            {
                track.TrackDate = DateTime.Now;
                track.TrackNote = "Updated";
                return track;
            });
        }

        [Fact]
        public Task Delete()
        {
            return _repositoryTestHelper.HasEntityDeleted(_seedTaskTracks.First());
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}