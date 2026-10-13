using EcoWater.API.Data;
using EcoWater.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcoWater.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    private readonly AppDbContext _context;

    public SensorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Listar(
        int page = 1,
        int pageSize = 10)
    {
        var sensores = await _context.Sensores
            .OrderBy(x => x.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return Ok(sensores);
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(
        Sensor sensor)
    {
        _context.Sensores.Add(sensor);

        await _context.SaveChangesAsync();

        return Created("", sensor);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(
        int id)
    {
        var sensor = await _context.Sensores
            .FindAsync(id);

        if (sensor == null)
            return NotFound();

        return Ok(sensor);
    }
}