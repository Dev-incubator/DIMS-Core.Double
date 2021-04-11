using System.Linq;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DIMS_Core.DataAccessLayer.Repositories
{
    public class VTaskRepository : ReadOnlyRepository<VTask>
    {
        public VTaskRepository(DIMSCoreContext context) : base(context)
        {

        }
    }
}