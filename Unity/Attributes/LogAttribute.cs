using System;
using System.Threading.Tasks;
// using AspectCore.DynamicProxy;
using Toolkit.Common.Log;

namespace Note.Unity.Attributes;

/// <summary>
/// 日志切面
/// </summary>
// public class LogAttribute:AbstractInterceptorAttribute
// {
//     public override async Task Invoke(AspectContext context, AspectDelegate next)
//     {
//         try
//         {
//             LogHelper.WriteLog("哈啊哈哈");
//             LogHelper.WriteLog($"调用{{context.ServiceMethod.Name}}方法 参数:{context.Parameters?.ToString()}");
//             LogHelper.WriteLog($"");
//             await next(context);
//             LogHelper.WriteLog($"调用{{context.ServiceMethod.Name}}方法 参数:{context.Parameters?.ToString()} 返回值:{context.ReturnValue?.ToString()}");
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e);
//             throw;
//         }
//     }
// }
