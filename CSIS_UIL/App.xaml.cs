using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CSIS_DataAccess;
using CSIS_UI_WPF.View;
using CSIS_UI_WPF.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;
using Autofac;

namespace CSIS_UI_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        MainWindowViewModel mainWindowViewModel;

        public App()
        {
            displayRootRegistry.RegisterWindowType<MainWindowViewModel, MainWindow>();
            displayRootRegistry.RegisterWindowType<FilteredWindowViewModel, FilteredView>();
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
                .BuildServiceProvider();
            /*var builder = new ContainerBuilder();
            BuildUpContainer(builder);*/
            
            
            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel();

            

            displayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}