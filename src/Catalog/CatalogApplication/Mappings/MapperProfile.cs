using AutoMapper;
using CatalogApplication.DTOs;
using CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogApplication.Features.Command;
using CatalogDomain.Aggregates;
using CatalogDomain.Entities;

namespace CatalogApplication.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CatalogItem, CatalogItemDTO>();
        CreateMap<Size, SizeDTO>().ReverseMap();
        CreateMap<UpdateCatalogItemCommand, CatalogItem>();
        CreateMap<CreateCatalogItemCommand, CatalogItem>();
    }
}
