using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RealEstate.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase {
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService) => _orderService = orderService;

    [Authorize]
    [HttpPost("{propertyId}")]
    public async Task<IActionResult> Create(string propertyId) {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value;
        if (string.IsNullOrEmpty(userId)) return Unauthorized();
        await _orderService.CreateOrderAsync(userId, propertyId);
        return Ok();
    }

    [Authorize]
    [HttpGet("my")]
    public async Task<IActionResult> MyOrders() {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? User.FindFirst(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value;
        var list = await _orderService.GetOrdersAsync(userId);
        return Ok(list);
    }
}