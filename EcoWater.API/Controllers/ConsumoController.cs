using EcoWater.API.Data;
using EcoWater.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoWater.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsumoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ConsumoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(
        ConsumoAgua consumo)
    {
        _context.Consumos.Add(consumo);

        await _context.SaveChangesAsync();

        return Created("", consumo);
    }

    [HttpGet]
    public async Task<IActionResult> Listar(
        int page = 1,
        int pageSize = 10)
    {
        var consumos = await _context.Consumos
            .OrderBy(c => c.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(consumos);
    }

    [HttpGet("vazamentos")]
    public IActionResult DetectarVazamentos()
    {
        return Ok(new
        {
            PossivelVazamento = false,
            Mensagem = "Nenhum vazamento detectado"
        });
    }

    [HttpGet("economia")]
    public IActionResult RelatorioEconomia()
    {
        return Ok(new
        {
            ConsumoMesAtual = 8000,
            ConsumoMesAnterior = 10000,
            EconomiaPercentual = 20
        });
    }
}