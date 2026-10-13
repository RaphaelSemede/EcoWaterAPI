using System.ComponentModel.DataAnnotations;

namespace EcoWater.API.Models;

public class Sensor
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = "";

    [Required]
    public string Localizacao { get; set; } = "";

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; } = DateTime.Now;
}