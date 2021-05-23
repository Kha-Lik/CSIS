using AutoMapper;
using Entities;
using Models;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cosmetic, CosmeticModel>().ReverseMap();
            CreateMap<Consignment, ConsignmentModel>().ReverseMap();
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<Purchase, PurchaseModel>().ReverseMap();
        }
    }
}