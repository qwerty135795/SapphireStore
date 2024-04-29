using CatalogApplication.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace CatalogInfrastructure.Extensions;

public static class PagedListExtensions
{
    public static async Task<PagedList<TEntity>> ToPagedList<TEntity>(this IQueryable<TEntity> query, int page, int pageSize)
    {
        var count = await query.CountAsync();
        query = query.Skip((page - 1) * pageSize).Take(pageSize);

        return new PagedList<TEntity>(await query.ToListAsync(), pageSize, page, count);
    }

    public static StringValues GetPaginationHeaders<TEntity>(this PagedList<TEntity> list)
    {
        return new StringValues([
            $"Page: {list.Page}", $"PageSize: {list.PageSize}",
            $"TotalPage: {list.TotalPage}", $"Count: {list.ItemsCount}"
        ]);
    }
}