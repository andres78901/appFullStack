using RealEstate.Api.Dtos;
namespace RealEstate.Api.Services {
    public interface IPropertyService {
        Task<(IEnumerable<PropertyDto> Items, long Total)> GetPropertiesAsync(string? name, string? address, decimal? priceMin, decimal? priceMax, int page, int pageSize);
        Task<PropertyDto?> GetByIdAsync(string id);
        Task<PropertyDto> CreateAsync(PropertyDto dto);
        Task<PropertyDto?> UpdateAsync(string id, PropertyDto dto);
        Task<bool> DeleteAsync(string id);
    }
}