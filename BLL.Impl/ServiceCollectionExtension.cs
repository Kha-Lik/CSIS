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
                .AddTransient<ICrudService<CosmeticModel>, CosmeticService>()
                .AddTransient<ICrudService<ClientModel>, ClientService>()
                .AddTransient<ICrudService<PurchaseModel>, PurchaseService>()
                .AddTransient<ICrudService<ConsignmentModel>, ConsignmentService>()
                .AddTransient<IFilterService, FilterService>()
                .AddTransient<ISellerService, SellerService>()
                .BindMapper();
        }
    }
}