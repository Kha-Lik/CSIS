using AutoMapper;
using Entities;
using Models;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cosmetic, CosmeticGetModel>().ReverseMap();
            CreateMap<Consignment, ConsignmentGetModel>().ReverseMap();
            CreateMap<Client, ClientGetModel>().ReverseMap();
            CreateMap<Purchase, PurchaseGetModel>().ReverseMap();
            CreateMap<CosmeticCreateUpdateModel, Cosmetic>();
            CreateMap<ClientCreateUpdateModel, Client>();
            CreateMap<PurchaseCreateUpdateModel, Purchase>();
            CreateMap<ConsignmentCreateUpdateModel, Consignment>();
        }
    }
}