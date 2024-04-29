using MediatR;

namespace CatalogApplication.Features.CatalogItem.Commands.DeleteCatalogItem;

public class DeleteCatalogItemCommand : IRequest
{
    public int Id { get; set; }
}