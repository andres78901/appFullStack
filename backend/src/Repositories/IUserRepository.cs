using RealEstate.Api.Models;
namespace RealEstate.Api.Repositories;
public interface IUserRepository {
    Task<User?> GetByEmailAsync(string email);
    Task CreateAsync(User user);
    Task<User?> GetByIdAsync(string id);
}