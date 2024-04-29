using CatalogApplication.Contracts;
using CatalogApplication.Features.Command;
using MediatR;

namespace CatalogApplication;

public class CreateCatalogItemCommandHandler
    : IRequestHandler<CreateCatalogItemCommand, int>
{
    private readonly ICatalogRepository _repository;

    public CreateCatalogItemCommandHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }
    public async Task<int> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var id = await _repository.CreateItem(request.CatalogItem);
        return id;
    }
}
