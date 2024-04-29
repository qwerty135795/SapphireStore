using CatalogApplication.DTOs;
using MediatR;

namespace CatalogApplication.Features.Queries.GetCatalogItems;
using CatalogDomain.Aggregates;

public class GetCatalogItemsQuery : IRequest<PagedList<CatalogItemDTO>>
{
    private int _page = 1;
    private int _pageSize = 10;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 0 && value < 25 ? value : 10;
    }
    public int Page
    {
        get => _page;
        set => _page = value > 0 ? value : 1;
    }
    public string? Gender { get; set; }
    public string? Type { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
}