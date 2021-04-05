using AutoMapper;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Models;


namespace DIMS_Core.BusinessLayer.MappingProfiles
{
    public class VUserProgressProfile : Profile
    {
        public VUserProgressProfile()
        {
            CreateMap<VUserProgressModel, VUserProgress>().ReverseMap();
        }
    }
}
