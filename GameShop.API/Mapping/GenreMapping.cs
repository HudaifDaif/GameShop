using GameShop.API.DTOs;
using GameShop.API.Entities;

namespace GameShop.API.Mapping;

public static class GenreMapping
{
    public static GenreDTO ToGenreDTO(this Genre genre)
    {
        return new GenreDTO(genre.Id, genre.Name);
    }
}
