using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class VUserProfileService : ReadOnlyService<VUserProfileModel, VUserProfile, IReadOnlyRepository<VUserProfile>>, IVUserProfileService
    {
        public VUserProfileService(IReadOnlyRepository<VUserProfile> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}