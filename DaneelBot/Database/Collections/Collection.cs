using DaneelBot.Utils;
using MongoDB.Driver;

namespace DaneelBot.Database.Collections;

public abstract class DaneelCollection {
    protected abstract string CollectionName { get; }
}

public abstract class DaneelCollection<T> : DaneelCollection {
    private readonly DBService _service = Services.Get<DBService>();

    protected IMongoCollection<T> Collection => _service.Database.GetCollection<T>(CollectionName);
}