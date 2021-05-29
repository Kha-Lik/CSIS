using DAL.Abstract;
using DAL.Impl.Repositories;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Impl
{
    public static class ServiceCollectionExtension
    {
        public static void AddDataServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<CsisDbContext>(x =>
                    x.UseSqlServer(connectionString))
            //serviceCollection.AddDbContext<CsisDbContext>(o => o.UseInMemoryDatabase("CSIS_DB"))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRepository<Cosmetic>, CosmeticRepository>()
                .AddScoped<IRepository<Client>, ClientRepository>()
                .AddScoped<IRepository<Purchase>, PurchaseRepository>()
                .AddScoped<IRepository<Consignment>, ConsignmentRepository>();
        }
    }
}