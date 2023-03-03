using System;
using System.Collections.Generic;
using DaneelBot.Database.Collections;
using DaneelBot.Models;
using DaneelBot.Utils;
using MongoDB.Driver;

namespace DaneelBot.Database;

public class DBService : Service {
    private const string ClientIp = "mongodb://localhost:27017";
    private const string DatabaseName = "daneelbotdb";

    private readonly Dictionary<Type, DaneelCollection> _collections = new Dictionary<Type, DaneelCollection>();

    private MongoClient? _client { get; set; }
    public IMongoDatabase Database { get; private set; } = null!;

    protected override void DoInit() {
        Connect();
        RegisterCollection<UserCollection>(new UserCollection());
        RegisterCollection<CandleCollection>(new CandleCollection());
    }

    public C Get<C>() where C : DaneelCollection {
        return (_collections[typeof(C)] as C)!;
    }
    
    private void Connect() {
        _client = new MongoClient(ClientIp);
        Database = _client.GetDatabase(DatabaseName);
    }

    private void RegisterCollection<T>(DaneelCollection collection) {
        if (_collections.ContainsKey(typeof(T))) {
            throw new ArgumentException("Collection already registered. Make sure the collection name is correct.");
        }
        
        _collections.Add(typeof(T), collection);
    }
}