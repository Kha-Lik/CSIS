using System;
using System.Configuration;
using System.Windows;
using BLL;
using BLL.Interfaces;
using BLL.Mapper;
using CSIS_UI_WPF;
using CSIS_UI_WPF.View;
using CSIS_UI_WPF.ViewModel;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace UIL
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<FilteredWindowViewModel, FilteredView>();
            
            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
        }
        public IServiceProvider ServiceProvider { get; set; }
        public DisplayRootRegistry DisplayRootRegistry { get; } = new DisplayRootRegistry();

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<CsisDbContext>(x =>
                    x.UseSqlServer(ConfigurationManager.ConnectionStrings["Csis"].ConnectionString))
                .AddScoped(typeof(ICosmeticRepository), typeof(CosmeticRepository))
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddScoped(typeof(IFacade), typeof(Facade))
                .AddTransient(typeof(ICosmeticService), typeof(CosmeticService))
                .AddTransient(typeof(IFilterService), typeof(FilterService))
                .BindMapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindowViewModel = new MainWindowViewModel((IFacade) ServiceProvider.GetService(typeof(IFacade)));
            DisplayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}