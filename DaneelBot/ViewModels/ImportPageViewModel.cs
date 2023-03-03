using System.Collections.ObjectModel;
using DynamicData.Binding;
using ReactiveUI;

namespace DaneelBot.ViewModels;

public class ImportPageViewModel : PageViewModel {
    private ObservableCollection<string> _exchangesCollection = new ObservableCollection<string>();

    public ObservableCollection<string> ExchangesCollection {
        get => _exchangesCollection;
        set => this.RaiseAndSetIfChanged(ref _exchangesCollection, value);
    }

    private ObservableCollection<string> _symbolsCollection = new ObservableCollection<string>();

    public ObservableCollection<string> SymbolsCollection {
        get => _symbolsCollection;
        set => this.RaiseAndSetIfChanged(ref _symbolsCollection, value);
    }

    public ImportPageViewModel(IScreen screen, int index) : base(screen, index) {
        ExchangesCollection.Add("Binance");
        SymbolsCollection.Add("BTCUSDT");
        SymbolsCollection.Add("ETHUSDT");
        SymbolsCollection.Add("ADAUSDT");
        SymbolsCollection.Add("BNBUSDT");
        SymbolsCollection.Add("BTCBNB");
    }
}