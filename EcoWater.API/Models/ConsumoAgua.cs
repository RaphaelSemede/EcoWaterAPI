using System.ComponentModel.DataAnnotations;

namespace EcoWater.API.Models;

public class ConsumoAgua
{
    public int Id { get; set; }

    [Required]
    public decimal LitrosConsumidos { get; set; }

    [Required]
    public string Localizacao { get; set; } = "";

    public DateTime DataLeitura { get; set; } = DateTime.Now;
}