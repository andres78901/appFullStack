   
using Microsoft.AspNetCore.Mvc;
using RealEstate.Api.Dtos;
using RealEstate.Api.Services;

namespace RealEstate.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase {
    private readonly IPropertyService _service;
    public PropertyController(IPropertyService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? name, [FromQuery] string? address, [FromQuery] decimal? priceMin, [FromQuery] decimal? priceMax, [FromQuery] int page = 1, [FromQuery] int pageSize = 20) {
        var (items, total) = await _service.GetPropertiesAsync(name, address, priceMin, priceMax, page, pageSize);
        return Ok(new { items, total });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id) {
        var dto = await _service.GetByIdAsync(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PropertyDto dto) {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] PropertyDto dto) {
        var updated = await _service.UpdateAsync(id, dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}