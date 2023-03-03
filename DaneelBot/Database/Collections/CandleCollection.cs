using System.Collections.Generic;
using System.Threading.Tasks;
using DaneelBot.Models;
using MongoDB.Driver;

namespace DaneelBot.Database.Collections;

public class CandleCollection : DaneelCollection<Candle> {
    protected override string CollectionName { get; } = "candle";

    public async Task<List<Candle>> GetAllCandles() {
        var filter = Builders<Candle>.Filter.Empty;
        var res = await Collection.FindAsync<Candle>(filter);
        return res.ToList();
    }

    public Task CreateCandle(Candle candle) {
        return Collection.InsertOneAsync(candle);
    }
    
    public Task CreateCandles(IEnumerable<Candle> candles) {
        return Collection.InsertManyAsync(candles);
    }

    public Task DeleteAllCandles() {
        return Collection.DeleteManyAsync(_ => true);
    }
}