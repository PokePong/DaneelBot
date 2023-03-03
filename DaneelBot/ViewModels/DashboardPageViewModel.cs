using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace DaneelBot.ViewModels;
public class DashboardPageViewModel : PageViewModel {
    private ObservableAsPropertyHelper<string> _myNameProperty;
    private string MyNameProperty => _myNameProperty.Value;

    public DashboardPageViewModel(IScreen screen, int index) : base(screen, index) {
        this.WhenAnyValue(x => x.MyName)
            .ToProperty(this, x => x.MyNameProperty, out _myNameProperty);
    }

    private string _myName = "Hello world!";

    public string MyName {
        get => _myName;
        set => this.RaiseAndSetIfChanged(ref _myName, value);
    }
}