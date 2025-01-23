using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
///
/// </summary>
public class Sale: BaseEntity
{

    /// <summary>
    /// Gets the Id sequence integer for sale number
    /// Not repeat and pk for entitie model
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the date of sale when the sale was made
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// Gets the Id customer from entitie model Customer from list of clients
    /// </summary>
    public int CustomerId { get; set; }
    /// <summary>
    /// Gets the total of price itens of products on this sale was made
    /// </summary>
    public decimal TotalSaleAmount { get; set; }
    /// <summary>
    /// Gets the Branch where the sale was made to segregation or filter
    /// </summary>
    public string Branch { get; set; }
    /// <summary>
    /// Gets the list items of entitie model products
    /// </summary>
    public List<SaleItem> Items { get; set; }
    /// <summary>
    /// Gets the Sale status to be cancelled or not
    /// </summary>
    public bool IsCancelled { get; set; }
       
  
    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        Date = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the Sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Sale</list>
    /// <list type="bullet">Role validity</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }


}