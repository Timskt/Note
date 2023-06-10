using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Note.Unity.Attributes;
using Toolkit.Common.Log;
using Toolkit.ViewModel.BaseViewModel;

namespace Note.ViewModels;

/// <summary>
/// 主界面
/// </summary>
public partial class MainContentViewModel:ChildViewModelBase
{
    public MainContentViewModel() : base()
    {
        
    }

    [RelayCommand]
    public async Task Test()
    {
        LogHelper.WriteLog("调用");
    }
}