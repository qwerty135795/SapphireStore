using CatalogApplication.DTOs;
using MediatR;

namespace CatalogApplication.Features.Size.Queries;

public class GetSizesQuery : IRequest<List<SizeDTO>>
{
    
}