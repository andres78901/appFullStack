using RealEstate.Api.Dtos;
namespace RealEstate.Api.Services;
public interface IOrderService {
    Task CreateOrderAsync(string userId, string propertyId);
    Task<IEnumerable<object>> GetOrdersAsync(string userId);
}