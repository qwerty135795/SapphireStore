using AutoMapper;
using CatalogApplication.Contracts;
using CatalogApplication.Features.Command;
using CatalogDomain.Aggregates;
using CatalogDomain.Entities;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CatalogApplication;

public class CreateCatalogItemCommandHandler
    : IRequestHandler<CreateCatalogItemCommand, int>
{
    private readonly ICatalogRepository _repository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IFileUploader _fileUploader;
    private readonly ILogger<CreateCatalogItemCommand> _logger;
    private readonly IMapper _mapper;

    public CreateCatalogItemCommandHandler(ICatalogRepository repository, IPublishEndpoint publishEndpoint,
        IFileUploader fileUploader, ILogger<CreateCatalogItemCommand> logger, IMapper mapper)
    {
        _repository = repository;
        _publishEndpoint = publishEndpoint;
        _fileUploader = fileUploader;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
    {
        var url = await _fileUploader.Upload(request.ColorStream, $"{request.Name}:{request.Color}");
        if (url is null)
        {
            _logger.LogWarning("url is null");
            return -1;
        }

        var item = _mapper.Map<CatalogItem>(request);
        item.Colors = [new Color(request.Color, url)];
        var id = await _repository.CreateItem(item);
        return id;
    }
}
