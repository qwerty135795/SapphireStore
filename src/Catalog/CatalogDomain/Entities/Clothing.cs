using CatalogDomain.Common;
using CatalogDomain.Entities;

namespace CatalogDomain;

public class Clothing : EntityBase
{
    public string Name { get; set; }
    public string Category { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
