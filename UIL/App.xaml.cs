using System;
using System.Windows;
using BLL;
using BLL.Abstract;
using DAL.Impl;
using Microsoft.Extensions.DependencyInjection;
using UIL.Services;
using UIL.View;
using ViewModels;

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
            serviceCollection.InstallDal();
            serviceCollection.InstallBll();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var command = new OpenFilteredWindowCommand {Facade = ServiceProvider.GetService<IFacade>()};
            var mainWindowViewModel =
                new MainWindowViewModel((IFacade) ServiceProvider.GetService(typeof(IFacade)), command);
            DisplayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}