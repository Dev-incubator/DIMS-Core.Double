using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class TaskTrackRepository : Repository<TaskTrack>
    {
        public TaskTrackRepository(DbContext context) : base(context)
        {
        }
    }
}
