using CatalogApplication.Contracts;
using CatalogApplication.DTOs;
using MediatR;

namespace CatalogApplication.Features.Size.Queries;

public class GetSizesQueryHandler : IRequestHandler<GetSizesQuery, List<SizeDTO>>
{
    private readonly ICatalogRepository _repository;

    public GetSizesQueryHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<SizeDTO>> Handle(GetSizesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetSizes();
    }
}