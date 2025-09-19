using RealEstate.Api.Models;
namespace RealEstate.Api.Repositories {
    public interface IPropertyRepository {
        Task<IEnumerable<Property>> GetAsync(string? name, string? address, decimal? priceMin, decimal? priceMax, int skip, int take);
        Task<Property?> GetByIdAsync(string id);
        Task CreateAsync(Property p);
        Task UpdateAsync(string id, Property property);
        Task DeleteAsync(string id);
    }
}