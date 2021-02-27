using DIMS_Core.DataAccessLayer.Models;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        ThreadTask DeleteUserProcedure(int id);
    }
}