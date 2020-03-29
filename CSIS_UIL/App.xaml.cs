using System.Windows;
using CSIS_BLL;
using CSIS_BLL.Interfaces;
using CSIS_BLL.Mapper;
using CSIS_DataAccess;
using CSIS_UI_WPF.View;
using CSIS_UI_WPF.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSIS_UI_WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry DisplayRootRegistry = new DisplayRootRegistry();
        private MainWindowViewModel mainWindowViewModel;

        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<FilteredWindowViewModel, FilteredView>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection()
                .AddDbContext<CsisDbContext>(x =>
                    x.UseSqlServer("Server=localhost;Database=CSIS_DB;Trusted_Connection=True;"))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddScoped(typeof(IFacade), typeof(Facade))
                .AddTransient(typeof(ICosmeticService), typeof(CosmeticService))
                .AddTransient(typeof(ICosmeticUsedSlowlyService), typeof(CosmeticUsedSlowlyService))
                .AddTransient(typeof(IFilterService), typeof(FilterService))
                .AddTransient(typeof(ISaverService), typeof(SaverService))
                .BindMapper()
                .BuildServiceProvider();


            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel((IFacade)services.GetService(typeof(IFacade)));


            DisplayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}