using RealEstate.Api.Models;
namespace RealEstate.Api.Repositories;
public interface IOrderRepository {
    Task CreateAsync(Order order);
    Task<IEnumerable<Order>> GetByUserAsync(string userId);
}