using RealEstate.Api.Dtos;
using RealEstate.Api.Models;
using RealEstate.Api.Repositories;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealEstate.Api.Services;
public class UserService : IUserService {
    private readonly IUserRepository _repo;
    private readonly IConfiguration _config;
    public UserService(IUserRepository repo, IConfiguration config) { _repo = repo; _config = config; }
    public async Task<string?> RegisterAsync(UserDto dto) {
        var exists = await _repo.GetByEmailAsync(dto.Email);
        if (exists != null) return null;
        var user = new User { Email = dto.Email, Name = dto.Name, PasswordHash = ComputeHash(dto.Password) };
        await _repo.CreateAsync(user);
        return user.Id;
    }
    public async Task<string?> AuthenticateAsync(UserDto dto) {
        var user = await _repo.GetByEmailAsync(dto.Email);
        if (user == null) return null;
        if (user.PasswordHash != ComputeHash(dto.Password)) return null;
        // create token
        var jwt = _config.GetSection("JwtSettings");
        var secret = jwt["Secret"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new[] { new Claim(JwtRegisteredClaimNames.Sub, user.Id ?? ""), new Claim(JwtRegisteredClaimNames.Email, user.Email) };
        var token = new JwtSecurityToken(jwt["Issuer"], jwt["Audience"], claims, expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwt["ExpiryMinutes"])), signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<UserDto?> GetByIdAsync(string id) {
        var u = await _repo.GetByIdAsync(id);
        if (u == null) return null;
        return new UserDto { Email = u.Email, Name = u.Name };
    }
    private static string ComputeHash(string input) {
        using var sha = SHA256.Create();
        var b = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(b);
    }
}