namespace CatalogApplication.Features.Command;
using MediatR;
using CatalogDomain.Aggregates;


public class CreateCatalogItemCommand : IRequest<int>
{
    public CatalogItem CatalogItem {get;init;}
}
