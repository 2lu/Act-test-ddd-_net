using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a user in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem: BaseEntity
{

    /// <summary>
    /// Id sequence integer for Sale Item number
    /// Not repeat and pk for entitie model
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the Product's full name.
    /// Must not be null or empty.
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// Gets the Quantity of sales item
    /// Must be 0 to empty
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// Gets the unit price item
    /// Must be  0 to empty
    /// </summary>
    public decimal UnitPrice { get; set; }
    /// <summary>
    /// Gets the the unit price discount item
    /// Must be 0 to empty
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Performs validation of the Sale entity using the SaleItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Sale items</list>
    /// <list type="bullet">Role validity</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

}