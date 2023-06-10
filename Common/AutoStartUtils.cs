using Microsoft.Win32;

namespace Note.Common;

/// <summary>
/// 开启自启动工具类
/// </summary>
public static class AutoStartUtils
{
    /// <summary>
    /// 开机自启代码，注册表方式
    /// </summary>
    public static void AutoStart()
    {
        RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        registryKey.SetValue("YourAppName", System.Reflection.Assembly.GetExecutingAssembly().Location);
    }
}