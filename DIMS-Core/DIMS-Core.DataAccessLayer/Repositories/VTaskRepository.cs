using System.Linq;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VTaskRepository : IReadOnlyRepository<VTask>
    {
        private readonly DIMSCoreContext _context;
        
        public VTaskRepository(DIMSCoreContext context)
        {
            _context = context;
        }

        public IQueryable<VTask> GetAll()
        {
            return _context.VTasks.AsNoTracking();
        }
    }
}