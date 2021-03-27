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
    public class UserTaskRepositoryTest : IDisposable
    {
        private readonly UserTaskRepositoryFixture _fixture;

        public UserTaskRepositoryTest()
        {
            // Arrange
            _fixture = new UserTaskRepositoryFixture();
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
            var result = await _fixture.Repository.GetById(_fixture.AddUserTaskId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.AddUserTaskId, result.UserTaskId);
            Assert.Equal(3, result.StateId);
            Assert.Equal(3, result.TaskId);
            Assert.Equal(3, result.UserId);
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
            var createdTaskTrack = new UserTask()
            {
                UserId = 4,
                TaskId = 4,
                StateId = 4

            };

            //Act
            var result = await _fixture.Repository.Create(createdTaskTrack);

            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.StateId);
            Assert.Equal(4, result.TaskId);
            Assert.Equal(4, result.UserId);


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

            var updatedUserTask = await _fixture.Context.UserTasks.FindAsync(_fixture.UpdateUserTaskId);
            updatedUserTask.StateId = 5;
            updatedUserTask.UserId = 5;
            updatedUserTask.TaskId = 5;

            //Act
            var result = _fixture.Repository.Update(updatedUserTask);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.UpdateUserTaskId, result.UserTaskId);
            Assert.Equal(5, result.StateId);
            Assert.Equal(5, result.TaskId);
            Assert.Equal(5, result.UserId);
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
            await _fixture.Repository.Delete(_fixture.DeleteUserTaskId);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.DoesNotContain(await _fixture.Context.UserTasks.FindAsync(_fixture.DeleteUserTaskId), _fixture.Repository.GetAll());
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

