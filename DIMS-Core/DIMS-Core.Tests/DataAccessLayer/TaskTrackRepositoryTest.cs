using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.DataAccessLayer.Fixtures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class TaskTrackRepositoryTest : IDisposable
    {
        private readonly TaskTrackRepositoryFixture _fixture;

        public TaskTrackRepositoryTest()
        {
            // Arrange
            _fixture = new TaskTrackRepositoryFixture();
        }

        [Fact]
        public async ThreadTask GetAll_OK()
        {
            //Act
            var result = _fixture.Repository.GetAll();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(3, await result.CountAsync());
        }

        [Fact]
        public async ThreadTask GetById_OK()
        {
            //Act
            var result = await _fixture.Repository.GetById(_fixture.AddTaskTrackId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.AddTaskTrackId, result.TaskTrackId);
            Assert.Equal(3, result.UserTaskId);
            Assert.Equal("AddNote", result.TrackNote);
        }

        [Fact]
        public ThreadTask GetById_IncorrectData_Fail()
        {
            //Act, Assert
            return Assert.ThrowsAsync<EntityNotExistException>(() => _fixture.Repository.GetById(int.MaxValue));
        }

        [Fact]
        public async ThreadTask Create_OK()
        {
            //Arrange
            var createdTaskTrack = new TaskTrack()
            {
                TrackNote = "NewNote",
                TrackDate = DateTime.Now.AddDays(10).Date,
                UserTaskId = 4

            };

            //Act
            var result = await _fixture.Repository.Create(createdTaskTrack);

            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(createdTaskTrack.TrackDate, result.TrackDate);
            Assert.Equal(createdTaskTrack.TrackNote, result.TrackNote);
            Assert.Equal(createdTaskTrack.UserTaskId, result.UserTaskId);
           
        }

        [Fact]
        public ThreadTask Create_IncorrectData_Fail()
        {

            //Act, Assert
            return Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Create(null));
        }

        [Fact]
        public async ThreadTask Update_OK()
        {
            //Arrange
            var updateTrackNote = "UpdatedNote";
            var updatedTrackDate = DateTime.Now.AddDays(3).Date;

            var updatedTaskTrack = await _fixture.Context.TaskTracks.FindAsync(_fixture.UpdateTaskTrackId);
            updatedTaskTrack.TrackNote = updateTrackNote;
            updatedTaskTrack.TrackDate = updatedTrackDate;

            //Act
            var result = _fixture.Repository.Update(updatedTaskTrack);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.UpdateTaskTrackId, result.TaskTrackId);
            Assert.Equal(updatedTrackDate, result.TrackDate);
            Assert.Equal(updateTrackNote, result.TrackNote);
        }

        [Fact]
        public void Update_IncorrectData_Fail()
        {
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        [Fact]
        public async ThreadTask Delete_OK()
        {
            //Act
            await _fixture.Repository.Delete(_fixture.DeleteTaskTrackId);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.DoesNotContain(await _fixture.Context.TaskTracks.FindAsync(_fixture.DeleteTaskTrackId), _fixture.Repository.GetAll());
        }

        [Fact]
        public ThreadTask Delete_IncorrectData_Fail()
        {
            //Act, Assert
            return Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Delete(int.MaxValue));
        }


        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
