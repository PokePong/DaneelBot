using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using DaneelBot.ViewModels;
using ReactiveUI;

namespace DaneelBot.Views;

public partial class DashboardView : ReactiveUserControl<DashboardPageViewModel> {

    public DashboardView() {
        this.WhenActivated(disposables => {
        });
        AvaloniaXamlLoader.Load(this);
    }
}