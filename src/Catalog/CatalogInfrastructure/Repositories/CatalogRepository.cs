using AutoMapper;
using AutoMapper.QueryableExtensions;
using CatalogApplication.Contracts;
using CatalogApplication.DTOs;
using CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogApplication.Features.Queries.GetCatalogItems;
using CatalogDomain.Aggregates;
using CatalogDomain.Entities;
using CatalogInfrastructure.Extensions;
using CatalogInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CatalogInfrastructure.Repositories;

public class CatalogRepository : ICatalogRepository
{
    private readonly CatalogDbContext _context;
    private readonly IMapper _mapper;

    public CatalogRepository(CatalogDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<int> CreateItem(CatalogItem item)
    {
        item.Sizes = await _context.Sizes.Where(s => item.Sizes.Select(s => s.Id).Contains(s.Id))
            .ToListAsync();
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item.Id;
    }

    public Task<CatalogItem?> GetItemById(int id) => 
        _context.Items.Include(i => i.Sizes)
            .FirstOrDefaultAsync(i => i.Id == id);

    public async Task DeleteItem(int id)
    {
        await _context.Items.Where(i => i.Id == id).ExecuteDeleteAsync();
    }

    public async Task UpdateItem(UpdateCatalogItemCommand item)
    {
        var updatedEntity = await _context.Items.Include(i => i.Sizes)
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.Id == item.Id);
        if (updatedEntity is null) return;
        _mapper.Map(item, updatedEntity, typeof(UpdateCatalogItemCommand), typeof(CatalogItem));
        _context.Entry(updatedEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<List<SizeDTO>> GetSizes()
    {
        return await _context.Sizes.ProjectTo<SizeDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<PagedList<CatalogItemDTO>> GetCatalog(GetCatalogItemsQuery query)
    {
        var itemsQuery = _context.Items.Include(i => i.Sizes)
            .AsNoTracking().AsQueryable();
        if (query.Gender != null)
        {
            itemsQuery = itemsQuery.Where(i => i.Gender == query.Gender.ToGender());
        }
        if (query.Type != null)
        {
            itemsQuery = itemsQuery.Where(i => query.Type == i.Category);
        }

        if (query.MinPrice != null)
        {
            itemsQuery = itemsQuery.Where(i => i.Price > query.MinPrice);
        }

        if (query.MaxPrice != null)
        {
            itemsQuery = itemsQuery.Where(i => i.Price < query.MaxPrice);
        }

        return await itemsQuery.ProjectTo<CatalogItemDTO>(_mapper.ConfigurationProvider)
            .ToPagedList(query.Page, query.PageSize);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}

file static class GenderExtensions
{
    public static Gender ToGender(this string gender)
    {
        return gender.ToLower() switch
        {
            "female" => Gender.Female,
            "male" => Gender.Male,
            _ => Gender.Unisex
        };
    }
}
