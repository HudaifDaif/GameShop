using System.ComponentModel.DataAnnotations;

namespace GameShop.API.DTOs;

public record class CreateGameDTO(
    [Required][StringLength(50)] string Name,
    [Required] int GenreId,
    [Range(0, 100)] decimal Price,
    DateOnly ReleaseDate
);
