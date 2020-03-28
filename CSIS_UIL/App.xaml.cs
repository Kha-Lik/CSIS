using System.Windows;
using Autofac;
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

        private void BuildUpContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CSIS_DBContext>().InstancePerRequest();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection()
                .AddDbContext<CSIS_DBContext>(x =>
                    x.UseSqlServer("Server=localhost;Database=CSIS_DB;Trusted_Connection=True;"))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork))
                .BindMapper()
                .BuildServiceProvider();


            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel();


            DisplayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}