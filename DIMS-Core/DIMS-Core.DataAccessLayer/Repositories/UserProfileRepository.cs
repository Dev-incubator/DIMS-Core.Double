using Microsoft.EntityFrameworkCore;


using System;
using System.Linq;
using DIMS_Core.DataAccessLayer.Interfaces;
 using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>
    {
        
        public UserProfileRepository(DIMSCoreContext context) : base(context)
        {
            
        }

        public override async  ThreadTask Delete(int userId)
        {
            await GetDatabaseFacade().ExecuteSqlRawAsync("Exec DeleteUser @UserId", userId);
        }
        
    }
}
