using System.Collections.Generic;
using System.Threading.Tasks;
using DaneelBot.Database.Dto;
using DaneelBot.Models;
using MongoDB.Driver;

namespace DaneelBot.Database.Collections;

public class UserCollection : DaneelCollection<UserDto> {
    protected override string CollectionName { get; } = "user";

    public async Task<List<UserDto>> GetAllUsers() {
        var filter = Builders<UserDto>.Filter.Empty;
        var res = await Collection.FindAsync(filter);
        return res.ToList();
    }

    public Task CreateUser(UserDto user) {
        return Collection.InsertOneAsync(user);
    }

    public Task UpdateUser(UserDto user) {
        var filter = Builders<UserDto>.Filter.Eq("Id", user.Id);
        return Collection.ReplaceOneAsync(filter, user, new ReplaceOptions() { IsUpsert = true });
    }

    public async Task<UserDto?> GetUserByEmail(string email) {
        var filter = Builders<UserDto>.Filter.Eq("Email", email);
        var res = await Collection.FindAsync(filter);
        return await res.FirstOrDefaultAsync();
    }
}