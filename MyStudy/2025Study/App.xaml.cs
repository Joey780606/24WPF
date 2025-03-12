using _2025Study.Core;
using _2025Study.MVVM.ViewModel;
using _2025Study.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace _2025Study
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;  //這是  Microsoft.Extensions.DependencyInjection library的類別

        public App()
        {
            IServiceCollection services = new ServiceCollection(); //這是  Microsoft.Extensions.DependencyInjection library的類別
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()      //重要,設定DataContext,寫法特別,帶參數
            });
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<Page001ViewModel>();
            services.AddSingleton<Page002ViewModel>();
            services.AddSingleton<Page020TaskViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType)); //ViewModel是 Core(自建的)ViewModel
            // 猜測 serviceProvider, viewModelType 都是變數的名稱, serviceProvider 是 IServiceProvider型態, viewModelType 是 Type型態

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)   //5:06 程式啟動時要先做的事
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            //mainWindow.DataContext = _serviceProvider.GetRequiredService<MainViewModel>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}