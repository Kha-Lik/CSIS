using System;
using System.Collections.Generic;
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

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection().AddDbContext<CSIS_DBContext>()
                .BuildServiceProvider();
            
            
            base.OnStartup(e);

            mainWindowViewModel = new MainWindowViewModel();

            

            displayRootRegistry.ShowModalPresentation(mainWindowViewModel);

            Shutdown();
        }
    }
}