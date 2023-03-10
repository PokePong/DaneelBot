using System;
using System.Diagnostics;
using DaneelBot.ViewModels;
using DaneelBot.Views;
using ReactiveUI;

namespace DaneelBot;

public class AppViewLocator : IViewLocator {
    public IViewFor ResolveView<T>(T viewModel, string? contract = null) {
        if (viewModel is not PageViewModel context) throw new ArgumentOutOfRangeException(nameof(viewModel));
        
        return context.PageIndex switch {
            0 => new DashboardView { DataContext = context },
            1 => new ImportView { DataContext = context },
            _ => throw new InvalidOperationException()
        };
    }
}