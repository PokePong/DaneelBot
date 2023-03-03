using System.Collections.Generic;
using System.Threading.Tasks;
using DaneelBot.Models;
using MongoDB.Driver;

namespace DaneelBot.Database.Collections;

public class UserCollection : DaneelCollection<User> {
    protected override string CollectionName { get; } = "user";

    public async Task<List<User>> GetAllUsers() {
        var res = await Collection.FindAsync(_ => true);
        return res.ToList();
    }

    public Task CreateUser(User user) {
        return Collection.InsertOneAsync(user);
    }

    public Task UpdateUser(User user) {
        var filter = Builders<User>.Filter.Eq("Id", user.Id);
        return Collection.ReplaceOneAsync(filter, user, new ReplaceOptions() { IsUpsert = true });
    }

    public async Task<User?> GetUserByEmail(string email) {
        var filter = Builders<User>.Filter.Eq("Email", email);
        var res = await Collection.FindAsync(filter);
        return await res.FirstOrDefaultAsync();
    }
}