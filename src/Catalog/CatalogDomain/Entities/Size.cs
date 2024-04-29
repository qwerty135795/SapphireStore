using CatalogDomain.Aggregates;

namespace CatalogDomain.Entities;

public class Size
{
    public int Id { get; set; }
    public int RussianSize { get; set; }
    public IEnumerable<CatalogItem> Items { get; set; } = new List<CatalogItem>();
}
