using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using MaterialDesign.Avalonia.PackIcon;
using ReactiveUI;

namespace DaneelBot.Models;

public class SideMenuItem {
    public string? Title { get; set; } = default;
    public PackIconKind Icon { get; set; } = PackIconKind.BoxOutline;
    public int Index { get; set; } = -1;
}

public class SideMenuModel : ReactiveObject {
    private bool _isPaneOpen = true;

    public bool IsPaneOpen {
        get => _isPaneOpen;
        set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
    }

    private List<SideMenuItem> _menuItems = new List<SideMenuItem>();

    public List<SideMenuItem> MenuItems {
        get => _menuItems;
        set => this.RaiseAndSetIfChanged(ref _menuItems, value);
    }

    private object _pageContent = new Grid();

    public object PageContent {
        get => _pageContent;
        set => this.RaiseAndSetIfChanged(ref _pageContent, value);
    }

    public delegate void OnPageChangedEvent(object sender, int index);

    public event OnPageChangedEvent OnPageChanged;

    public void ToggleSideMenu() {
        IsPaneOpen = !IsPaneOpen;
    }

    public void GoToPage(int index) {
        OnPageChanged?.Invoke(this, index);
    }
}