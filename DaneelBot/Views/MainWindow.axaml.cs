using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DaneelBot.ViewModels;
using ReactiveUI;

namespace DaneelBot.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {

    public RoutingState Router => ViewModel?.Router;
    
    public MainWindow() {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);

#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void SideMenuModel_OnPageChanged(object sender, int index) {
        ViewModel?.RunToPage(index);
    }
}