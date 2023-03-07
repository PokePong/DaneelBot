using System;
using DaneelBot.Exchange;
using DaneelBot.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaneelBot.Database.Dto;

public class CandleDto : DtoModel {
    public DateTime Date { get; set; }

    public decimal Open { get; set; }

    public decimal Close { get; set; }

    public decimal High { get; set; }

    public decimal Low { get; set; }

    public decimal Volume { get; set; }

    public string Symbol { get; set; }

    public ExchangeType Exchange { get; set; }

    public Timeframe Timeframe { get; set; }
}