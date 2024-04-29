using FluentValidation;

namespace CatalogApplication.Features.Command;

public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogItemCommand>
{
    public  CreateCatalogCommandValidator() 
    {
        RuleFor(req => req.CatalogItem.Colors).NotEmpty()
            .Must(req => req.Any()).WithMessage("Need at least 1 colour");
        RuleFor(req => req.CatalogItem.Price).NotEmpty().WithMessage("Price is required property")
            .GreaterThan(0).WithMessage("Price must be greater than zero");
        RuleFor(req => req.CatalogItem.Sizes).NotEmpty()
            .Must(req => req.Any()).WithMessage("Need at least 1 size");
    }
}
