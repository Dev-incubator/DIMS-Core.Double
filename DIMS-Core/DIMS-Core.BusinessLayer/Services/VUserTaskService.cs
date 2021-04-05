using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserTaskService : ReadOnlyService<VUserTaskModel, VUserTask, IReadOnlyRepository<VUserTask>>
    {
        public VUserTaskService(IReadOnlyRepository<VUserTask> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}