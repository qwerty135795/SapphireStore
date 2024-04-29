using CatalogApplication.Contracts;
using MediatR;

namespace CatalogApplication.Features.CatalogItem.Commands.DeleteCatalogItem;

public class DeleteCatalogItemCommandHandler : IRequestHandler<DeleteCatalogItemCommand>
{
    private readonly ICatalogRepository _repository;

    public DeleteCatalogItemCommandHandler(ICatalogRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteCatalogItemCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteItem(request.Id);
    }
}