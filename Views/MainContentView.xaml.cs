using System.Windows.Controls;
using CommunityToolkit.Mvvm.DependencyInjection;
using Note.ViewModels;

namespace Note.Views;

public partial class MainContentView : UserControl
{
    public MainContentView()
    {
        InitializeComponent();
        DataContext = Ioc.Default.GetRequiredService<MainContentViewModel>();
    }
}