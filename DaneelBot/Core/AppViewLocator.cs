using System;
using DaneelBot.ViewModels;
using DaneelBot.Views;
using ReactiveUI;

namespace DaneelBot.Core;

public class AppViewLocator : ReactiveUI.IViewLocator {
    // public IViewFor ResolveView<T>(T viewModel, string? contract = null) => viewModel switch
    // {
    //     PageViewModel context => new FirstView { DataContext = context },
    //     _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    // };


    public IViewFor ResolveView<T>(T viewModel, string? contract = null) {
        if (viewModel is not PageViewModel context) throw new ArgumentOutOfRangeException(nameof(viewModel));

        return context.PageIndex switch {
            0 => new DashboardView { DataContext = context },
            1 => new ImportView() { DataContext = context },
            _ => throw new InvalidOperationException()
        };
    }
}