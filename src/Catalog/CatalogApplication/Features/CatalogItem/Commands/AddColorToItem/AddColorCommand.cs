using MediatR;

namespace CatalogApplication.Features.Commands.AddColorToItem;

public class AddColorCommand : IRequest
{
    public int Id { get; set; }
    public string Color { get; set; }
    public Stream Stream { get; set; }
}