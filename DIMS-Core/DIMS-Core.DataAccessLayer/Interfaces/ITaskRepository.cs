using EntityTask = DIMS_Core.DataAccessLayer.Models.Task;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Interfaces
{
    public interface ITaskRepository : IRepository<EntityTask>
    {
        ThreadTask DeleteTaskProcedure(int id);
    }
}