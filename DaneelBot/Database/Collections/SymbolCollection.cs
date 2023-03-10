using System.Collections.Generic;
using System.Threading.Tasks;
using DaneelBot.Database.Dto;
using DaneelBot.Exchange;
using MongoDB.Driver;

namespace DaneelBot.Database.Collections;

public class SymbolCollection : DaneelCollection<SymbolDto> {
    protected override string CollectionName { get; } = "symbol";

    public async Task<List<SymbolDto>> GetAllSymbols() {
        var filter = Builders<SymbolDto>.Filter.Empty;
        var res = await Collection.FindAsync<SymbolDto>(filter);
        return res.ToList();
    }

    public async Task<List<SymbolDto>> GetAllSymbols(ExchangeType exchangeType) {
        var filter = Builders<SymbolDto>.Filter.Eq("ExchangeType", exchangeType);
        var res = await Collection.FindAsync<SymbolDto>(filter);
        return res.ToList();
    }

    public Task CreateSymbol(SymbolDto symbol) {
        return Collection.InsertOneAsync(symbol);
    }

    public Task CreateSymbols(IEnumerable<SymbolDto> symbols) {
        return Collection.InsertManyAsync(symbols);
    }

    public Task DeleteAllSymbols() {
        return Collection.DeleteManyAsync(_ => true);
    }
}