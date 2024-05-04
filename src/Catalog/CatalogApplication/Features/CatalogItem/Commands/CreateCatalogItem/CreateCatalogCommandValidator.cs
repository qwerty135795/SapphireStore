using FluentValidation;

namespace CatalogApplication.Features.Command;

public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogItemCommand>
{
    public  CreateCatalogCommandValidator() 
    {
    }
}
