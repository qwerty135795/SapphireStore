using AutoMapper;
using CatalogAPI.DTOs;
using CatalogApplication.DTOs;
using CatalogApplication.Features.CatalogItem.Commands.DeleteCatalogItem;
using CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;
using CatalogApplication.Features.Command;
using CatalogApplication.Features.Commands.AddColorToItem;
using CatalogApplication.Features.Queries;
using CatalogApplication.Features.Queries.GetCatalogItems;
using CatalogApplication.Features.Size.Queries;
using CatalogDomain.Aggregates;
using CatalogInfrastructure.Extensions;
using MassTransit;
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
    public async Task<ActionResult<int>> CreateCatalogItem([FromForm]CreateItemDTO itemDTO)
    {
        await using var stream = itemDTO.ColorDto.File.OpenReadStream(); 
        var command = _mapper.Map<CreateCatalogItemCommand>(itemDTO);
        command.ColorStream = stream;
        var id = await _mediator.Send( command );
        return Ok(new {CreatedId = id});
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CatalogItemDTO>> GetCatalogItemById(int id)
    {
        var item = await _mediator.Send(new GetCatalogItemByIdQuery { Id = id});
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

    [HttpPost("{id:int}")]
    public async Task<ActionResult> AddColor(int id, string color, IFormFile file)
    {
        await using var stream = file.OpenReadStream();
        await _mediator.Send(new AddColorCommand { Id = id, Color = color, Stream = stream });
        return NoContent();
    }
}
