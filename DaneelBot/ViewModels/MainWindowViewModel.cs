using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using DaneelBot.Database;
using DaneelBot.Database.Collections;
using DaneelBot.Database.Dto;
using DaneelBot.Exchange;
using DaneelBot.Models;
using DaneelBot.Utils;
using MongoDB.Driver;
using ReactiveUI;

namespace DaneelBot.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen {
    public RoutingState Router { get; } = new RoutingState();

    public ReactiveCommand<Unit, IRoutableViewModel> GoToDashboard { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToImport { get; }

    private const int NbPage = 4;
    private int _currentPageIndex = -1;
    private readonly PageViewModel[] _pages = new PageViewModel[NbPage];

    public MainWindowViewModel() {
        var dashboardView = new DashboardPageViewModel(this, 0);
        var importView = new ImportPageViewModel(this, 1);

        RegisterPage(dashboardView);
        RegisterPage(importView);

        GoToDashboard = ReactiveCommand.CreateFromObservable(() => GoToPage(0));
        GoToImport = ReactiveCommand.CreateFromObservable(() => GoToPage(1));

        TestDb();
        TestBinance();
    }

    private async Task TestBinance() {
        var _service = Services.Get<BinanceService>();
        var candleCollection = Services.Get<DBService>().Get<CandleCollection>();

        var candles =
            await _service.DownloadCandles("BTCUSDT", Timeframe.MINUTE_1, DateTime.Today.AddDays(-3), DateTime.Today);

        await candleCollection.DeleteAllCandles();
        await candleCollection.CreateCandles(candles);
    }

    private async Task TestDb() {
        var service = Services.Get<DBService>();
        var userCollection = service.Get<UserCollection>();
        var users = await userCollection.GetAllUsers();
        Debug.WriteLine("Total users: " + users.Count);

        const string email = "loic.besse98@gmail.com";

        var connectingUser = await userCollection.GetUserByEmail(email);

        if (connectingUser != null) {
            connectingUser.TotalConnexion += 1;
            connectingUser.LastConnexion = DateTime.Now;
            await userCollection.UpdateUser(connectingUser);
        }
        else {
            var user = new UserDto() {
                FirstName = "Loïc",
                LastName = "Besse",
                Email = email,
                LastConnexion = DateTime.Now,
                TotalConnexion = 1
            };
            await userCollection.CreateUser(user);
        }
    }

    private IObservable<IRoutableViewModel> GoToPage(int index) {
        if (index == _currentPageIndex) return Observable.Empty<IRoutableViewModel>();
        _currentPageIndex = index;
        return Router.Navigate.Execute(_pages[index]);
    }

    private void RegisterPage(PageViewModel pageViewModel) {
        _pages[pageViewModel.PageIndex] = pageViewModel;
    }
}