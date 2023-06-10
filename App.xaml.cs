using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Note.Common.DataBase;
using Note.Unity.Consts;
using Note.ViewModels;
using Note.Views;
using Toolkit.Common.Log;
using Toolkit.Common.Router;

namespace Note;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        InitConfig();
        Ioc.Default.ConfigureServices(ConfigureServiceProvider());
        RegisterRouter();
        //UI线程未捕获异常处理时间(UI主线程)
        DispatcherUnhandledException += App_DispatcherUnhandledException;
        //Task线程内未捕获异常处理事件
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        //非UI线程未捕获异常处理事件
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        base.OnStartup(e);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        Environment.Exit(0);
    }

    //依赖注入
    private IServiceProvider ConfigureServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<DbContext, DataContext>();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<MainContentViewModel>();

        return services.BuildServiceProvider();
    }

    /// <summary>
    ///     注册路由
    /// </summary>
    private void RegisterRouter()
    {
        //设置程序第一页
        var firstView = new MainContentView();
        RouterHelper.IniView(firstView);
        RouterHelper.AddRouter("mainContent", firstView);
        // RouterHelper.AddRouterByClassType("mainRouter",typeof(MainWindowViewModel),true);
    }

    /// <summary>
    ///     读取配置文件
    /// </summary>
    private void InitConfig()
    {
        //设置log文件打印位置
        LogHelper.LogFilePath = ConfigurationManager.AppSettings["logPath"] ?? ConfigConst.LogPath;
    }

    /// <summary>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        try
        {
            var exception = e.Exception;
            var msg = $"{exception.Message}\n\n{exception.StackTrace}";
            LogHelper.WriteLog(msg);
            e.Handled = true; //表示异常已经处理可以继续运行
        }
        catch (Exception e1)
        {
            LogHelper.WriteLog(e1.Message);
        }
    }

    /// <summary>
    ///     task线程未捕获异常处理事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        try
        {
            Exception exception = e.Exception;
            var msg = $"{exception.Message}\n\n{exception.StackTrace}";
            LogHelper.WriteLog(msg);
        }
        catch (Exception e1)
        {
            LogHelper.WriteLog(e1.Message);
        }
    }

    //非UI线程未捕获异常处理事件(例如自己创建的一个子线程)     
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        try
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                var msg = $"{exception.Message}\n\n{exception.StackTrace}";
                LogHelper.WriteLog(msg);
            }
        }
        catch (Exception e1)
        {
            LogHelper.WriteLog(e1.Message);
        }
    }
}