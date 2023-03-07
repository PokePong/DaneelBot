using System.Collections.Generic;
using System.Threading.Tasks;
using DaneelBot.Database.Dto;
using MongoDB.Driver;

namespace DaneelBot.Database.Collections;

public class CandleCollection : DaneelCollection<CandleDto> {
    protected override string CollectionName { get; } = "candle";

    public async Task<List<CandleDto>> GetAllCandles() {
        var filter = Builders<CandleDto>.Filter.Empty;
        var res = await Collection.FindAsync<CandleDto>(filter);
        return res.ToList();
    }

    public Task CreateCandle(CandleDto candle) {
        return Collection.InsertOneAsync(candle);
    }
    
    public Task CreateCandles(IEnumerable<CandleDto> candles) {
        return Collection.InsertManyAsync(candles);
    }

    public Task DeleteAllCandles() {
        return Collection.DeleteManyAsync(_ => true);
    }
}