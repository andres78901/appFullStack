using RealEstate.Api.Dtos;
using RealEstate.Api.Models;
using RealEstate.Api.Repositories;
using System.Linq;

namespace RealEstate.Api.Services {
    public class PropertyService : IPropertyService {
        private readonly IPropertyRepository _repo;
        public PropertyService(IPropertyRepository repo) { _repo = repo; }
        public async Task<(IEnumerable<PropertyDto> Items, long Total)> GetPropertiesAsync(string? name, string? address, decimal? priceMin, decimal? priceMax, int page, int pageSize) {
            var skip = (page - 1) * pageSize;
            var items = await _repo.GetAsync(name, address, priceMin, priceMax, skip, pageSize);
            var list = items.Select(p => new PropertyDto { Id = p.Id, IdOwner = p.IdOwner, Name = p.Name, AddressProperty = p.AddressProperty, PriceProperty = p.PriceProperty, ImageUrl = p.ImageUrl });
            return (list, list.LongCount());
        }
        public async Task<PropertyDto?> GetByIdAsync(string id) {
            var p = await _repo.GetByIdAsync(id);
            return p == null ? null : new PropertyDto { Id = p.Id, IdOwner = p.IdOwner, Name = p.Name, AddressProperty = p.AddressProperty, PriceProperty = p.PriceProperty, ImageUrl = p.ImageUrl };
        }
        public async Task<PropertyDto> CreateAsync(PropertyDto dto) {
            var p = new Property { IdOwner = dto.IdOwner, Name = dto.Name, AddressProperty = dto.AddressProperty, PriceProperty = dto.PriceProperty, ImageUrl = dto.ImageUrl };
            await _repo.CreateAsync(p);
            dto.Id = p.Id;
            return dto;
        }
        public async Task<PropertyDto?> UpdateAsync(string id, PropertyDto dto) {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;
            existing.Name = dto.Name;
            existing.AddressProperty = dto.AddressProperty;
            existing.PriceProperty = dto.PriceProperty;
            existing.ImageUrl = dto.ImageUrl;
            // Si quieres permitir actualizar el owner, descomenta la siguiente línea
            // existing.IdOwner = dto.IdOwner;
            await _repo.UpdateAsync(id, existing);
            return new PropertyDto {
                Id = existing.Id,
                IdOwner = existing.IdOwner,
                Name = existing.Name,
                AddressProperty = existing.AddressProperty,
                PriceProperty = existing.PriceProperty,
                ImageUrl = existing.ImageUrl
            };
        }
        public async Task<bool> DeleteAsync(string id) {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            await _repo.DeleteAsync(id);
            return true;
        }
    }
}