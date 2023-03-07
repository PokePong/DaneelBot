using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Linq;
using Avalonia.Controls;
using DynamicData.Binding;
using ReactiveUI;

namespace DaneelBot.ViewModels;

public class ImportPageViewModel : PageViewModel {
    #region Exchanges Collection

    private ObservableCollection<string> _exchangesCollection = new ObservableCollection<string>();

    public ObservableCollection<string> ExchangesCollection {
        get => _exchangesCollection;
        set => this.RaiseAndSetIfChanged(ref _exchangesCollection, value);
    }

    #endregion

    #region Symbols Collection

    private ObservableCollection<string> _symbolsCollection = new ObservableCollection<string>();

    public ObservableCollection<string> SymbolsCollection {
        get => _symbolsCollection;
        set => this.RaiseAndSetIfChanged(ref _symbolsCollection, value);
    }

    #endregion

    private int _selectedExchangeIndex;
    public int SelectedExchangeIndex {
        get => _selectedExchangeIndex;
        set => this.RaiseAndSetIfChanged(ref _selectedExchangeIndex, value);
    }

    public ImportPageViewModel(IScreen screen, int index) : base(screen, index) {
        ExchangesCollection.Add("Binance");
        ExchangesCollection.Add("Forex");
        SymbolsCollection.Add("BTCUSDT");
        SymbolsCollection.Add("ETHUSDT");
        SymbolsCollection.Add("ADAUSDT");
        SymbolsCollection.Add("BNBUSDT");
        SymbolsCollection.Add("BTCBNB");
        
        this.WhenAnyValue(x => x.SelectedExchangeIndex)
            .Subscribe(i => {
                Debug.WriteLine("Nouveau exchange ! " + SelectedExchangeIndex);
            });
    }
}