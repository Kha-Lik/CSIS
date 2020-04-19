using System;
using System.Configuration;
using System.Windows;
using BLL;
using BLL.Abstract;
using BLL.Mapper;
using BLL.Services;
using CSIS_UI_WPF;
using CSIS_UI_WPF.Services;
using CSIS_UI_WPF.View;
using CSIS_UI_WPF.ViewModel;
using DAL.Abstract;
using DAL.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UIL.Services;

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

            var command = new OpenFilteredWindowCommand(){Facade = ServiceProvider.GetService<IFacade>()};
            var mainWindowViewModel = new MainWindowViewModel((IFacade) ServiceProvider.GetService(typeof(IFacade)), command);
            DisplayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}