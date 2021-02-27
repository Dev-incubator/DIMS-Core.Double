using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using EntityTask = DIMS_Core.DataAccessLayer.Models.Task;
using Microsoft.EntityFrameworkCore;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskRepository : Repository<EntityTask>, ITaskRepository
    {
        private readonly DIMSCoreContext _context;
        public TaskRepository(DIMSCoreContext context) : base(context)
        {
            _context = context;
        }

        public async ThreadTask DeleteTaskProcedure(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("Exec DeleteTask @TaskId", id);
        }
    }
}