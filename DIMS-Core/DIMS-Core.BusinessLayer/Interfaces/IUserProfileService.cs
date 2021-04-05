using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIMS_Core.BusinessLayer.Models;

namespace DIMS_Core.BusinessLayer.Interfaces
{

    public interface IUserProfileService : IService<UserProfileModel>
    {
        public bool Equal(UserProfileModel userModel1, UserProfileModel userModel2);
        public bool NotEqual(UserProfileModel userModel1, UserProfileModel userModel2);
    }
}
