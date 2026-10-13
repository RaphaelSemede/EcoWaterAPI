using System.ComponentModel.DataAnnotations;

namespace EcoWater.API.Models;

public class Alerta
{
    public int Id { get; set; }

    [Required]
    public string Mensagem { get; set; } = "";

    public bool Resolvido { get; set; } = false;

    public DateTime DataCriacao { get; set; } = DateTime.Now;
}