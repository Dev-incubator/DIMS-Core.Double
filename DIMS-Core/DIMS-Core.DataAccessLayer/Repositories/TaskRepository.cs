using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskRepository : Repository<Task>
    {
        private readonly DIMSCoreContext _context;
        
        public TaskRepository(DIMSCoreContext context) : base(context)
        {
            _context = context;
        }

        public override async ThreadTask Delete(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("Exec DeleteTask @TaskId", id);
        }
    }
}