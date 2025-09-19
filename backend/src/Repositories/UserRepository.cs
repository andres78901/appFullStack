using MongoDB.Driver;
using RealEstate.Api.Models;
using Microsoft.Extensions.Options;

namespace RealEstate.Api.Repositories;
public class UserRepository : IUserRepository {
    private readonly IMongoCollection<User> _collection;
    public UserRepository(MongoDB.Driver.MongoClient client, IOptions<MongoSettings> opts) {
        var db = client.GetDatabase(opts.Value.DatabaseName);
        _collection = db.GetCollection<User>("users");
    }
    public async Task<User?> GetByEmailAsync(string email) => await _collection.Find(u => u.Email == email).FirstOrDefaultAsync();
    public async Task CreateAsync(User user) => await _collection.InsertOneAsync(user);
    public async Task<User?> GetByIdAsync(string id) => await _collection.Find(u => u.Id == id).FirstOrDefaultAsync();
}