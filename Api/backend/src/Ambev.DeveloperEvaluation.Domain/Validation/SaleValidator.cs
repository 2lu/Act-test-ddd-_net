using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
       RuleFor(sale => sale.Branch)
            .NotEmpty()
            .MinimumLength(3).WithMessage("Branch must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Branch cannot be longer than 50 characters.");
        
        
        RuleFor(sale => sale.Items)
            .NotEmpty()
            .WithMessage("Sale items cannot be empty.");
    }
}
