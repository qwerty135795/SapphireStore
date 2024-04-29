using AutoMapper;
using CatalogAPI.DTOs;
using CatalogApplication.DTOs;
using CatalogApplication.Features.CatalogItem.Commands.DeleteCatalogItem;
using CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogApplication.Features.Command;
using CatalogApplication.Features.Queries;
using CatalogApplication.Features.Queries.GetCatalogItems;
using CatalogApplication.Features.Size.Queries;
using CatalogDomain.Aggregates;
using CatalogInfrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CatalogController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<ActionResult<int>> CreateCatalogItem(CreateItemDTO itemDTO)
    {
        var id = await _mediator.Send(new CreateCatalogItemCommand { CatalogItem = _mapper.Map<CatalogItem>(itemDTO)});
        return Ok(new {CreatedId = id});
    }
    [HttpGet("{Id:int}")]
    public async Task<ActionResult<CatalogItemDTO>> GetCatalogItemById(int Id)
    {
        var item = await _mediator.Send(new GetCatalogItemByIdQuery { Id = Id});
        return item is null ? NotFound() : Ok(item);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCatalogItem(int id)
    {
        await _mediator.Send(new DeleteCatalogItemCommand { Id = id });
        return NoContent();
    }
    [HttpPut]
    public async Task<ActionResult> UpdateCatalogItem(UpdateItemDTO dto )
    {
        await _mediator.Send( _mapper.Map<UpdateCatalogItemCommand>(dto) );
        return NoContent();
    }
    [HttpGet("/Sizes")]
    public async Task<ActionResult<List<SizeDTO>>> GetItemSizes()
    {
        return await _mediator.Send(new GetSizesQuery());
    }
    [HttpGet]
    public async Task<ActionResult<List<CatalogItemDTO>>> GetCatalogItems([FromQuery]GetCatalogItemsQuery request)
    {
        var result = await _mediator.Send(request);

        Response.Headers.Append("pagination-xxx", result.GetPaginationHeaders());

        return result;
    }
}
