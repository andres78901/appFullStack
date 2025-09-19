using RealEstate.Api.Dtos;
namespace RealEstate.Api.Services;
public interface IUserService {
    Task<string?> RegisterAsync(UserDto dto);
    Task<string?> AuthenticateAsync(UserDto dto);
    Task<UserDto?> GetByIdAsync(string id);
}