using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using System.Collections.Generic;
using Serilog;


/// <summary>
/// Controller for managing user operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of UsersController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new sales
    /// </summary>
    /// <param name="command">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sales details</returns>
    [HttpPost]
    public async Task<ActionResult<Sale>> Create([FromBody] CreateSaleCommand command)
    {
        var saleResponse = await _mediator.Send(command);
        Log.Information("Sales created. Number: "+ saleResponse.Id.ToString()   +" in " + DateTime.Now.ToLongDateString());
        return Created(string.Empty, new ApiResponseWithData<CreateSaleCommand>
        {
            Success = true,
            Message = "Sales created successfully",
            Data = _mapper.Map<CreateSaleCommand>(saleResponse)
        });
    }

    /// <summary>
    /// Get all sales
    /// </summary>
    /// <param name="command">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>List of sales</returns>
    [HttpGet]
    public async Task<ActionResult<List<Sale>>> GetAll()
    {
        var saleResponse = await _mediator.Send(new GetAllSalesQuery());
         return Created(string.Empty, new ApiResponseWithData<GetAllSalesQuery>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = _mapper.Map<GetAllSalesQuery> (saleResponse)
        });
    }

    /// <summary> 
    /// Update a sale
    /// </summary>
    /// <param name="command">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update sale details</returns>
    [HttpPut]
    public async Task<IActionResult> Update(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var saleResponse = await _mediator.Send(command);
        Log.Information("Sales Number: " + saleResponse.Id.ToString() + " update in " + DateTime.Now.ToLongDateString());

        return Created(string.Empty, new ApiResponseWithData<UpdateSaleCommand>
        {
            Success = true,
            Message = "Sales update successfully",
            Data = _mapper.Map<UpdateSaleCommand>(saleResponse)
        });
    }

    /// <summary>
    /// Delete a sale
    /// </summary>
    /// <param name="request">The user creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sales details</returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(CancelSaleCommand command, CancellationToken cancellationToken)
    {
        var saleResponse = await _mediator.Send(command);
        Log.Information("Sales Number: " + command.SaleId.ToString() + " canseled in " + DateTime.Now.ToLongDateString());

        return Created(string.Empty, new ApiResponseWithData<UpdateSaleCommand>
        {
            Success = true,
            Message = "Sales canceled successfully",
            Data = _mapper.Map<UpdateSaleCommand>(saleResponse)
        });
    }

}
