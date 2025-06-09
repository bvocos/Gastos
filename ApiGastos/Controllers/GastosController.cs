using ApiGastos.Dto;
using ApiGastos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiGastos.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GastosController : ControllerBase
{
    private readonly AppDbContext _context;
    public GastosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetList")]
    public async Task<ActionResult<IEnumerable<GastosDto>>> Get()
    {
        var features = await _context.Gastos.ToListAsync();

        var featureDto = features.Select(f => new GastosDto
        {
            Id = f.Id,
            Monto = f.Monto,
            Fecha = f.Fecha,
            Descripcion = f.Descripcion.Trim(),
            NombreComercio = f.NombreComercio.Trim(),
        })
            .OrderByDescending(u => u.Id)
            .ToList();

        return Ok(featureDto);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<GastosDto>> Post(Gasto gasto)
    {
        if (gasto.Monto <= 0 ||
            gasto.Descripcion.Length < 3 || gasto.Descripcion.Length > 250 ||
            gasto.Fecha > DateTime.Today ||
            string.IsNullOrWhiteSpace(gasto.NombreComercio) || gasto.NombreComercio.Length > 250)
        {
            return BadRequest("Validaciones fallidas");
        }
        _context.Gastos.Add(gasto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = gasto.Id }, gasto);
    }
}
