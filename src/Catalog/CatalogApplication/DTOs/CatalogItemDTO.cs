using CatalogDomain.Entities;

namespace CatalogApplication.DTOs;

public class CatalogItemDTO
{

    public int Id { get; set; }
    public string Category { get; set; }
    public string Gender { get; set; } 
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<SizeDTO> Sizes { get; set; }
    public List<Color> Colors { get; set; }
}
