using AutoMapper;
using CatalogApplication.Contracts;
using CatalogApplication.DTOs;
using MediatR;

namespace CatalogApplication.Features.Queries;

public class GetCatalogItemByIdQueryHandler : IRequestHandler<GetCatalogItemByIdQuery, CatalogItemDTO?>
{
    private readonly ICatalogRepository _repository;
    private readonly IMapper _mapper;

    public GetCatalogItemByIdQueryHandler(ICatalogRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CatalogItemDTO?> Handle(GetCatalogItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetItemById(request.Id);
        if (item is null) return null;
        return _mapper.Map<CatalogItemDTO>(item);
    }
}
