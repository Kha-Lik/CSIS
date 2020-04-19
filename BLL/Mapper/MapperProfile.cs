using AutoMapper;
using DAL;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CosmeticEntity, CosmeticModel>().ReverseMap();
        }
    }
}