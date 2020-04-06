using System.Configuration;
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
        private MainWindowViewModel _mainWindowViewModel;

        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<FilteredWindowViewModel, FilteredView>();
        }

        public DisplayRootRegistry DisplayRootRegistry { get; } = new DisplayRootRegistry();

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection()
                .AddDbContext<CsisDbContext>(x =>
                    x.UseSqlServer(ConfigurationManager.ConnectionStrings["Csis"].ConnectionString))
                .AddScoped(typeof(ICosmeticRepository), typeof(CosmeticRepository))
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddScoped(typeof(IFacade), typeof(Facade))
                .AddTransient(typeof(ICosmeticService), typeof(CosmeticService))
                .AddTransient(typeof(IFilterService), typeof(FilterService))
                .BindMapper()
                .BuildServiceProvider();


            base.OnStartup(e);

            _mainWindowViewModel = new MainWindowViewModel((IFacade) services.GetService(typeof(IFacade)));
            DisplayRootRegistry.ShowModalPresentation(_mainWindowViewModel);

            Shutdown();
        }
    }
}