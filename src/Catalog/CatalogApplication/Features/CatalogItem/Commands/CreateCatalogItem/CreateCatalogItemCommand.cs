using CatalogApplication.DTOs;
using CatalogDomain.Entities;

namespace CatalogApplication.Features.Command;
using MediatR;


public class CreateCatalogItemCommand : IRequest<int>
{

    public string Name { get; set; }
    public string Category { get; set; }
    public Gender ItemGender { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<SizeDTO> Sizes { get; set; }
    public string Color { get; set; }
    public Stream ColorStream { get; set; }
}
