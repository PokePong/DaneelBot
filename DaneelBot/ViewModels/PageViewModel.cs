using System;
using ReactiveUI;

namespace DaneelBot.ViewModels;

public abstract class PageViewModel : ReactiveObject, IRoutableViewModel {
    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];
    public IScreen HostScreen { get; }
    public int PageIndex { get; }

    protected PageViewModel(IScreen screen, int index) {
        HostScreen = screen;
        PageIndex = index;
    }

}