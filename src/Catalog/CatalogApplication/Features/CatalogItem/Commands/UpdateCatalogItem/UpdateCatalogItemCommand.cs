using CatalogApplication.DTOs;
using CatalogDomain.Entities;
using MediatR;

namespace CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogDomain.Aggregates;

public class UpdateCatalogItemCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public Gender Gender { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<SizeDTO> Sizes { get; set; }
    public List<Color> Colors { get; set; }
}