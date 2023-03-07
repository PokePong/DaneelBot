using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Binance.Net.Clients;
using Binance.Net.Enums;
using DaneelBot.Database.Dto;
using DaneelBot.Models;
using DaneelBot.Utils;
using MongoDB.Bson;

namespace DaneelBot.Exchange;

public class BinanceService : Service {

    private const int KlinesLimit = 1000;
    
    private BinanceClient _client;

    protected override void DoInit() {
        Connect();
    }

    private void Connect() {
        _client = new BinanceClient();
    }

    public async Task<IEnumerable<CandleDto>> DownloadCandles(string symbol, Timeframe timeframe, DateTime start, DateTime end) {
        var result =
            await _client.SpotApi.ExchangeData.GetKlinesAsync(symbol, ToBinanceInterval(timeframe), start, end, KlinesLimit);
        var binanceKlines = result.Data.ToList();
        return binanceKlines.Select(i => new CandleDto {
            Date = i.CloseTime,
            Open = i.OpenPrice,
            Close = i.ClosePrice,
            High = i.HighPrice,
            Low = i.LowPrice,
            Volume = i.Volume,
            Symbol = symbol,
            Exchange = ExchangeType.BINANCE_SPOT,
            Timeframe = timeframe
        });
    }

    private static KlineInterval ToBinanceInterval(Timeframe timeframe) {
        return timeframe switch {
            Timeframe.MINUTE_1 => KlineInterval.OneMinute,
            Timeframe.MINUTE_3 => KlineInterval.ThreeMinutes,
            Timeframe.MINUTE_5 => KlineInterval.FiveMinutes,
            Timeframe.MINUTE_15 => KlineInterval.FifteenMinutes,
            Timeframe.MINUTE_30 => KlineInterval.ThirtyMinutes,
            Timeframe.HOUR_1 => KlineInterval.OneHour,
            Timeframe.HOUR_2 => KlineInterval.TwoHour,
            Timeframe.HOUR_4 => KlineInterval.FourHour,
            Timeframe.HOUR_6 => KlineInterval.SixHour,
            Timeframe.HOUR_8 => KlineInterval.EightHour,
            Timeframe.HOUR_12 => KlineInterval.TwelveHour,
            Timeframe.DAY_1 => KlineInterval.OneDay,
            Timeframe.DAY_3 => KlineInterval.ThreeDay,
            Timeframe.WEEK_1 => KlineInterval.OneWeek,
            Timeframe.MONTH_1 => KlineInterval.OneMonth,
            _ => throw new ArgumentOutOfRangeException(nameof(timeframe), timeframe, null)
        };
    }
}