using EcoWater.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoWater.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{
    private readonly AppDbContext _context;

    public RelatorioController(AppDbContext context)
    {
        _context = context;
    }

[HttpGet("economia")]
public async Task<IActionResult> Economia()
{
    var consumos = await _context.Consumos.ToListAsync();

    var total = consumos.Sum(c => c.LitrosConsumidos);

    return Ok(new
    {
        ConsumoTotal = total,
        EconomiaEstimada = total * 0.15m
    });
}

[HttpGet("consumo-mensal")]
public async Task<IActionResult> ConsumoMensal()
{
    var consumos = await _context.Consumos.ToListAsync();

    var total = consumos.Sum(c => c.LitrosConsumidos);

    return Ok(new
    {
        Mes = DateTime.Now.Month,
        Ano = DateTime.Now.Year,
        ConsumoTotal = total
    });
}
}