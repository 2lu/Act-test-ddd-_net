using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(sale => sale.Discount)
             .NotEmpty()
             .GreaterThanOrEqualTo(0).WithMessage("Discount not be negative");
      
    }
}

