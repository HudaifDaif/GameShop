using System.ComponentModel.DataAnnotations;

namespace GameShop.API.DTOs;

public record class UpdateGameDTO(
    [Required] [StringLength(50)] string Name,
    int GenreId,
    [Range(0, 100)] decimal Price,
    DateOnly ReleaseDate
);
