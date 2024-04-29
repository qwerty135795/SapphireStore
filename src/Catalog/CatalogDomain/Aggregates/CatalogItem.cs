using CatalogDomain.Entities;

namespace CatalogDomain.Aggregates;

public class CatalogItem : Clothing
{
    public IEnumerable<Size> Sizes { get; set; } = new List<Size>();
    public IEnumerable<Color> Colors { get; set; } = new List<Color>();
}
