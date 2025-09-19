using RealEstate.Api.Models;
using RealEstate.Api.Repositories;

namespace RealEstate.Api.Services;
public class OrderService : IOrderService {
    private readonly IOrderRepository _repo;
    public OrderService(IOrderRepository repo) { _repo = repo; }
    public async Task CreateOrderAsync(string userId, string propertyId) {
        var order = new Order { UserId = userId, PropertyId = propertyId, CreatedAt = DateTime.UtcNow };
        await _repo.CreateAsync(order);
    }
    public async Task<IEnumerable<object>> GetOrdersAsync(string userId) {
        var list = await _repo.GetByUserAsync(userId);
        return list.Select(o => new { o.Id, o.PropertyId, o.CreatedAt });
    }
}