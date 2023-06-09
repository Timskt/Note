using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Note.ViewModels;
using Note.Views;
using Toolkit.Common.Log;
using Toolkit.Common.Router;

namespace Note
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitConfig();
            Ioc.Default.ConfigureServices(ConfigureServiceProvider());
            RegisterRouter();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
        
        //依赖注入
        private IServiceProvider ConfigureServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainWindowViewModel>();
            return services.BuildServiceProvider();
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        private void RegisterRouter()
        {
            //设置程序第一页
            var firstView = new MainContentView();
            RouterHelper.IniView(firstView);
            RouterHelper.AddRouter("mainContent",firstView);
            // RouterHelper.AddRouterByClassType("mainRouter",typeof(MainWindowViewModel),true);
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void InitConfig()
        {
            //设置log文件打印位置
            LogHelper.LogFilePath = "log/log.txt";
        }
        
        
    }
}