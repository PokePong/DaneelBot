using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DaneelBot.Models;
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

    #region Import Config

    private DateTime _selectedStartDate;

    public DateTime SelectedStartDate {
        get => _selectedStartDate;
        set {
            this.RaiseAndSetIfChanged(ref _selectedStartDate, value);
            _importConfig.Start = value;
            SelectedStartDateStringFormat = value.ToString("dd/MM/yyyy");
            UpdateCanImportValue();
        }
    }

    private string _selectedStartDateStringFormat;

    public string SelectedStartDateStringFormat {
        get => _selectedStartDateStringFormat;
        set => this.RaiseAndSetIfChanged(ref _selectedStartDateStringFormat, value);
    }

    private int _selectedExchangeIndex;

    public int SelectedExchangeIndex {
        get => _selectedExchangeIndex;
        set {
            this.RaiseAndSetIfChanged(ref _selectedExchangeIndex, value);
            _importConfig.Exchange = value != -1 ? ExchangesCollection[value] : null;

            UpdateCanImportValue();
        }
    }

    private int _selectedSymbolIndex;

    public int SelectedSymbolIndex {
        get => _selectedSymbolIndex;
        set {
            this.RaiseAndSetIfChanged(ref _selectedSymbolIndex, value);
            _importConfig.Symbol = value != -1 ? SymbolsCollection[value] : null;
            UpdateCanImportValue();
        }
    }

    #endregion

    #region Import State

    private bool _isImporting = false;

    public bool IsImporting {
        get => _isImporting;
        set => this.RaiseAndSetIfChanged(ref _isImporting, value);
    }

    public bool _canImport;

    public bool CanImport {
        get => _canImport;
        set => this.RaiseAndSetIfChanged(ref _canImport, value);
    }

    #endregion

    private int _downloadProgressPerc;

    public int DownloadProgressPerc {
        get => _downloadProgressPerc;
        set => this.RaiseAndSetIfChanged(ref _downloadProgressPerc, value);
    }

    public ReactiveCommand<Unit, bool> DoImportCommand { get; set; }
    private ImportConfig _importConfig { get; set; }

    public ImportPageViewModel(IScreen screen, int index) : base(screen, index) {
        _importConfig = new ImportConfig();

        DoImportCommand = ReactiveCommand.CreateFromObservable(RunImport);

        ResetImportConfig();

        ExchangesCollection.Add("Binance");
        ExchangesCollection.Add("Forex");
        SymbolsCollection.Add("BTCUSDT");
        SymbolsCollection.Add("ETHUSDT");
        SymbolsCollection.Add("ADAUSDT");
        SymbolsCollection.Add("BNBUSDT");
        SymbolsCollection.Add("BTCBNB");
    }

    private void UpdateCanImportValue() {
        if (!string.IsNullOrEmpty(_importConfig.Exchange) && !string.IsNullOrEmpty(_importConfig.Symbol) &&
            _importConfig.Start != null) {
            CanImport = true;
            return;
        }

        CanImport = false;
    }

    private void ResetImportConfig() {
        SelectedStartDate = DateTime.Today;
        SelectedExchangeIndex = -1;
        SelectedSymbolIndex = -1;
    }

    private IObservable<bool> RunImport() {
        Observable.StartAsync(async ct => {
            IsImporting = true;
            while (DownloadProgressPerc < 100) {
                await Task.Delay(500, ct);
                DownloadProgressPerc += 10;
            }

            DownloadProgressPerc = 100;
            await Task.Delay(500, ct);
            DownloadProgressPerc = 0;
            ResetImportConfig();
            IsImporting = false;
            return true;
        }).ObserveOn(RxApp.MainThreadScheduler);
        return Observable.Empty<bool>();
    }
}