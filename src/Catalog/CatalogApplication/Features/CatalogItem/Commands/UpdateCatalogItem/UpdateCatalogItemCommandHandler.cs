using CatalogApplication.Contracts;
using MediatR;

namespace CatalogApplication.Features.CatalogItem.Commands.UpdateCatalogItem;

public class UpdateCatalogItemCommandHandler : IRequestHandler<UpdateCatalogItemCommand>
{
    private readonly ICatalogRepository _repository;

    public UpdateCatalogItemCommandHandler(ICatalogRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }
    public async Task Handle(UpdateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateItem(request);
    }               
}