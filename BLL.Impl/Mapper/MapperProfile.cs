using AutoMapper;
using DAL.Impl;
using Entities;
using Models;

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