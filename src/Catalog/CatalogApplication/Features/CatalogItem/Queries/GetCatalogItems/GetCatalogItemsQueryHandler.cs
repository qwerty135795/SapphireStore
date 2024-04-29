using CatalogApplication.Contracts;
using CatalogApplication.DTOs;
using MediatR;

namespace CatalogApplication.Features.Queries.GetCatalogItems;

public class GetCatalogItemsQueryHandler : IRequestHandler<GetCatalogItemsQuery, PagedList<CatalogItemDTO>>
{
    private readonly ICatalogRepository _repository;

    public GetCatalogItemsQueryHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }
    public async Task<PagedList<CatalogItemDTO>> Handle(GetCatalogItemsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetCatalog(request);
    }
}