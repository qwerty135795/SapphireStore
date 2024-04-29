namespace CatalogApplication.DTOs;

public class PagedList<TEntity> : List<TEntity>
{
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int ItemsCount { get; set; }
    public int TotalPage { get; set; }

    public PagedList(IList<TEntity> items,int pageSize, int page, int itemsCount)
    {
        PageSize = pageSize;
        Page = page;
        ItemsCount = itemsCount;
        TotalPage = (int)Math.Ceiling(itemsCount / (double)pageSize);
        AddRange(items);
    }

    public override string ToString()
    {
        return
            $"{nameof(PageSize)}: {PageSize}, {nameof(Page)}: {Page}, {nameof(ItemsCount)}: {ItemsCount}, {nameof(TotalPage)}: {TotalPage}";
    }
}