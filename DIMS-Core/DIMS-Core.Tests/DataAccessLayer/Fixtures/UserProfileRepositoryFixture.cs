using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public class UserProfileRepositoryFixture : BaseRepositoryFixture<UserProfileRepository>
    {
        public int UpdateUserProfileId { get; set; }
        public int DeleteUserProfileId { get; set; }
        public int AddUserProfileId { get; set; }

        protected override UserProfileRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDatabase()
        {
            UpdateUserProfileId = (await Context.AddAsync(new UserProfile
            {
                Address = "UpdateAddress",
                MobilePhone = "UpdatePhone",
                Skype = "UpdateSkype",
                Email = "UpdateEmail",
                DirectionId = 1,
                StartDate = DateTime.Now.AddDays(10).Date
            })).Entity.UserId;

            DeleteUserProfileId = (await Context.AddAsync(new UserProfile
            {
                Address = "DeleteAddress",
                MobilePhone = "DeletePhone",
                Skype = "DeleteSkype",
                Email = "DeleteEmail",
                DirectionId = 2,
                StartDate = DateTime.Now.AddDays(5).Date
            })).Entity.UserId;

            AddUserProfileId = (await Context.AddAsync(new UserProfile
            {
                Address = "AddAddress",
                MobilePhone = "AddPhone",
                Skype = "AddSkype",
                Email = "AddEmail",
                DirectionId = 3,
                StartDate = DateTime.Now.AddDays(1).Date
            })).Entity.UserId;

            await Context.SaveChangesAsync();
        }
    }
}
