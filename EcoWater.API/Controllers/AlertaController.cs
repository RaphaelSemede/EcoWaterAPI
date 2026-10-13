using EcoWater.API.Data;
using EcoWater.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoWater.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertaController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlertaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Listar(
        int page = 1,
        int pageSize = 10)
    {
        var alertas = await _context.Alertas
            .OrderByDescending(a => a.DataCriacao)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(alertas);
    }

    [HttpPost("gerar")]
    public async Task<IActionResult> Gerar()
    {
        var alerta = new Alerta
        {
            Mensagem =
                "Consumo acima do limite permitido."
        };

        _context.Alertas.Add(alerta);

        await _context.SaveChangesAsync();

        return Ok(alerta);
    }

    [HttpPut("{id}/resolver")]
    public async Task<IActionResult> Resolver(
        int id)
    {
        var alerta =
            await _context.Alertas.FindAsync(id);

        if (alerta == null)
            return NotFound();

        alerta.Resolvido = true;

        await _context.SaveChangesAsync();

        return Ok(alerta);
    }
}