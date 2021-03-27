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
    public class UserProfileRepositoryTest : IDisposable
    {
        private readonly UserProfileRepositoryFixture _fixture;

        public UserProfileRepositoryTest()
        {
            // Arrange
            _fixture = new UserProfileRepositoryFixture();
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
            var result = await _fixture.Repository.GetById(_fixture.AddUserProfileId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.AddUserProfileId, result.UserId);
            Assert.Equal("AddPhone", result.MobilePhone);
            Assert.Equal("AddAddress", result.Address);
            Assert.Equal("AddEmail", result.Email);
            Assert.Equal("AddSkype", result.Skype);
            Assert.Equal(DateTime.Now.AddDays(1).Date, result.StartDate);
            Assert.Equal(3, result.DirectionId);
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
            var createdUserProfile = new UserProfile
            {
                Address = "AddAddress",
                MobilePhone = "AddPhone",
                Skype = "AddSkype",
                Email = "AddEmail",
                DirectionId = 3,
                StartDate = DateTime.Now.AddDays(10).Date
            };

            //Act
            var result = await _fixture.Repository.Create(createdUserProfile);

            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(createdUserProfile.UserId, result.UserId);
            Assert.Equal(createdUserProfile.MobilePhone, result.MobilePhone);
            Assert.Equal(createdUserProfile.Address, result.Address);
            Assert.Equal(createdUserProfile.Email, result.Email);
            Assert.Equal(createdUserProfile.Skype, result.Skype);
            Assert.Equal(createdUserProfile.StartDate, result.StartDate);
            Assert.Equal(createdUserProfile.DirectionId, result.DirectionId);
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

            var updatedUserTask = await _fixture.Context.UserProfiles.FindAsync(_fixture.UpdateUserProfileId);
            updatedUserTask.Address = "UpdateAddress";
            updatedUserTask.MobilePhone = "UpdatePhone";
            updatedUserTask.Skype = "UpdateSkype";
            updatedUserTask.Email = "UpdateEmail";
            updatedUserTask.DirectionId = 1;
            updatedUserTask.StartDate = DateTime.Now.AddDays(100).Date;

            //Act
            var result = _fixture.Repository.Update(updatedUserTask);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.UpdateUserProfileId, result.UserId);
            Assert.Equal("UpdatePhone", result.MobilePhone);
            Assert.Equal("UpdateAddress", result.Address);
            Assert.Equal("UpdateEmail", result.Email);
            Assert.Equal("UpdateSkype", result.Skype);
            Assert.Equal(DateTime.Now.AddDays(100).Date, result.StartDate);
            Assert.Equal(1, result.DirectionId);
        }

        [Fact]
        public void Update_IncorrectData_Fail()
        {
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}
