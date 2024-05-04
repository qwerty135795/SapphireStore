using AutoMapper;
using CatalogAPI.DTOs;
using CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogApplication.Features.Command;
using CatalogDomain.Aggregates;
using CatalogDomain.Entities;

namespace CatalogAPI.Mappings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateItemDTO, CatalogItem>();
        CreateMap<UpdateItemDTO, UpdateCatalogItemCommand>();
        CreateMap<CreateItemDTO, CreateCatalogItemCommand>().ForMember(o => o.Color,
            src => src.MapFrom(path => path.ColorDto.Color));
    }
}