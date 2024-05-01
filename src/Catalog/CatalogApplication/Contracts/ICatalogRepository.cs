using CatalogApplication.DTOs;
using CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogApplication.Features.Queries.GetCatalogItems;
using CatalogDomain.Aggregates;

namespace CatalogApplication.Contracts;

public interface ICatalogRepository
{
    Task<int> CreateItem(CatalogItem item);
    Task<CatalogItem?> GetItemById(int id);
    Task DeleteItem(int id);
    Task UpdateItem(UpdateCatalogItemCommand item);
    Task<List<SizeDTO>> GetSizes();
    Task<PagedList<CatalogItemDTO>> GetCatalog(GetCatalogItemsQuery query);
    Task<int> SaveChangesAsync();
}
