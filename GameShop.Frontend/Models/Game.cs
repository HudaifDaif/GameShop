using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GameShop.Frontend.Models;

public class Game
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Genre { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
