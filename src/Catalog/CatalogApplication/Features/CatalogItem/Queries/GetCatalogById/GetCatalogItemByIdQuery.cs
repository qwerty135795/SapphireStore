using CatalogApplication.DTOs;
using MediatR;

namespace CatalogApplication.Features.Queries;

public class GetCatalogItemByIdQuery : IRequest<CatalogItemDTO?>
{
    public int Id { get; set; }
}
