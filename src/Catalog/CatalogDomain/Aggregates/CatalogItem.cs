using CatalogDomain.Entities;

namespace CatalogDomain.Aggregates;

public class CatalogItem : Clothing
{
    public ICollection<Size> Sizes { get; set; } = new List<Size>();
    public ICollection<Color> Colors { get; set; } = new List<Color>();
}
