using DAL.Abstract;
using DAL.Impl.Repositories;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Impl
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<CsisDbContext>(x =>
                    x.UseSqlServer(connectionString))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRepository<Cosmetic>, CosmeticRepository>()
                .AddScoped<IRepository<Client>, ClientRepository>()
                .AddScoped<IRepository<Purchase>, PurchaseRepository>()
                .AddScoped<IRepository<Consignment>, ConsignmentRepository>()
                .AddDefaultIdentity<User>(opt =>
                {
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireDigit = true;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<CsisDbContext>()
                .AddSignInManager();

            return serviceCollection;
        }
    }
}