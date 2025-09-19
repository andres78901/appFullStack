using MongoDB.Driver;
using RealEstate.Api.Models;
using Microsoft.Extensions.Options;

namespace RealEstate.Api.Repositories {
    public class PropertyRepository : IPropertyRepository {
        private readonly IMongoCollection<Property> _collection;
        public PropertyRepository(MongoDB.Driver.MongoClient client, IOptions<MongoSettings> opts) {
            var db = client.GetDatabase(opts.Value.DatabaseName);
            _collection = db.GetCollection<Property>("properties");
        }
        public async Task<IEnumerable<Property>> GetAsync(string? name, string? address, decimal? priceMin, decimal? priceMax, int skip, int take) {
            var filter = Builders<Property>.Filter.Empty;
            if (!string.IsNullOrWhiteSpace(name)) filter &= Builders<Property>.Filter.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(name, "i"));
            if (!string.IsNullOrWhiteSpace(address)) filter &= Builders<Property>.Filter.Regex(p => p.AddressProperty, new MongoDB.Bson.BsonRegularExpression(address, "i"));
            if (priceMin.HasValue) filter &= Builders<Property>.Filter.Gte(p => p.PriceProperty, priceMin.Value);
            if (priceMax.HasValue) filter &= Builders<Property>.Filter.Lte(p => p.PriceProperty, priceMax.Value);
            return await _collection.Find(filter).Skip(skip).Limit(take).ToListAsync();
        }
        public async Task<Property?> GetByIdAsync(string id) => await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Property property) => await _collection.InsertOneAsync(property);
        public async Task UpdateAsync(string id, Property property) {
            await _collection.ReplaceOneAsync(p => p.Id == id, property);
        }
        public async Task DeleteAsync(string id) {
            await _collection.DeleteOneAsync(p => p.Id == id);
        }
    }
}