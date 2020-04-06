using AutoMapper;
using CSIS_BusinessLogic;
using CSIS_DataAccess;

namespace CSIS_BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CosmeticEntity, CosmeticModel>().ReverseMap();
            //CreateMap<CosmeticUsedSlowlyEnity, CosmeticUsedSlowlyModel>().ReverseMap();
        }
    }
}