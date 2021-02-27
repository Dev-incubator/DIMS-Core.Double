using System.Linq;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VUserTaskRepository : IReadOnlyRepository<VUserTask>

    {
        private readonly DIMSCoreContext _context;
        public VUserTaskRepository(DIMSCoreContext context) 
        {
            _context = context;
        }

        public IQueryable<VUserTask> GetAll()
        {
            return _context.VUserTasks.AsNoTracking();
        }
    }
}