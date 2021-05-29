using BLL.Abstract;
using BLL.Mapper;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Models;

namespace BLL
{
    public static class ServiceCollectionExtension
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICrudService<CosmeticGetModel, CosmeticCreateUpdateModel>, CosmeticService>()
                .AddTransient<ICrudService<ClientGetModel, ClientCreateUpdateModel>, ClientService>()
                .AddTransient<ICrudService<PurchaseGetModel, PurchaseCreateUpdateModel>, PurchaseService>()
                .AddTransient<ICrudService<ConsignmentGetModel, ConsignmentCreateUpdateModel>, ConsignmentService>()
                .AddTransient<IFilterService, FilterService>()
                .AddTransient<ISellerService, SellerService>()
                .BindMapper();
        }
    }
}