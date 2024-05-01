using CatalogApplication.Contracts;
using CatalogDomain.Entities;
using MediatR;

namespace CatalogApplication.Features.Commands.AddColorToItem;

public class AddColorCommandHandler : IRequestHandler<AddColorCommand>
{
    private readonly ICatalogRepository _repository;
    private readonly IFileUploader _uploader;

    public AddColorCommandHandler(ICatalogRepository repository, IFileUploader uploader)
    {
        _repository = repository;
        _uploader = uploader;
    }
    public async Task Handle(AddColorCommand request, CancellationToken cancellationToken)
    {
        var url = await _uploader.Upload(request.Stream, $"{request.Id}:{request.Color}");
        if (url is null) return;
        var item = await _repository.GetItemById(request.Id);
        if (item is null) return;
        item.Colors.Add(new(request.Color, url));
        await _repository.SaveChangesAsync();
    }
}