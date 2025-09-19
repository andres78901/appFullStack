using MongoDB.Driver;
using RealEstate.Api.Models;
using Microsoft.Extensions.Options;

namespace RealEstate.Api.Repositories;
public class OrderRepository : IOrderRepository {
    private readonly IMongoCollection<Order> _collection;
    public OrderRepository(MongoDB.Driver.MongoClient client, IOptions<MongoSettings> opts) {
        var db = client.GetDatabase(opts.Value.DatabaseName);
        _collection = db.GetCollection<Order>("orders");
    }
    public async Task CreateAsync(Order order) => await _collection.InsertOneAsync(order);
    public async Task<IEnumerable<Order>> GetByUserAsync(string userId) => await _collection.Find(o => o.UserId == userId).ToListAsync();
}