using System.Configuration;
using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Impl
{
    public static class DalInstaller
    {
        public static void InstallDal(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CsisDbContext>(x =>
                    x.UseSqlServer(ConfigurationManager.ConnectionStrings["Csis"].ConnectionString))
            //serviceCollection.AddDbContext<CsisDbContext>(o => o.UseInMemoryDatabase("CSIS_DB"))
                .AddSingleton<IUnitOfWork, UnitOfWork>()
                .AddSingleton<ICosmeticRepository, CosmeticRepository>();
        }
    }
}