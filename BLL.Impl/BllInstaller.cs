using BLL.Abstract;
using BLL.Mapper;
using BLL.Services;
using DAL.Abstract;
using DAL.Impl.BS;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BllInstaller
    {
        public static void InstallBll(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICosmeticService, CosmeticService>()
                .AddSingleton<IFilterService, FilterService>()
                .AddSingleton<IFacade, Facade>()
                .AddSingleton<ISerializer, BinarySerializer>()
                .BindMapper();
        }
    }
}