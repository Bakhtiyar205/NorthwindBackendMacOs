using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(m => m.ProductName).NotEmpty();
        RuleFor(m => m.ProductName).Length(2, 30);
        RuleFor(m => m.UnitPrice).NotEmpty();
        RuleFor(m => m.UnitPrice).GreaterThanOrEqualTo(1);
        RuleFor(m => m.UnitPrice).GreaterThanOrEqualTo(10).When(m => m.CategoryId == 1);
        RuleFor(m => m.ProductName).Must(StartWithWithA);
    }

    private bool StartWithWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}