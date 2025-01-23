using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using NSubstitute;
using System.Reflection.Metadata;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSaleHandler"/> class.
/// </summary>
public class CreateSaleHandlerTests
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleHandlerTests()
    {
        _saleRepository = Substitute.For<ISaleRepository>();
        _mapper = Substitute.For<IMapper>();
   }
     
    /// <summary>
    /// Tests that a valid user creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given a new Sale data When creating Sale Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given

        var sale = new Sale
        {
            Id = 1,
            Branch = "Test",
            Items = new List<SaleItem>() { new SaleItem() { Id=1,UnitPrice=41.11m } }
        };
        
        var command = new CreateSaleCommand { Id = 1, CustomerId = 1, Items = { new SaleItem { Id = 1, UnitPrice = 41.11m } } };
        var _handler = new CreateSaleCommandHandler(_saleRepository);

        _mapper.Map<Sale>(command).Returns(sale);
        _mapper.Map<Sale>(sale).Returns(sale);

        // When
        var createUserResult  = await _handler.Handle(command, CancellationToken.None);

       
        // Then
        createUserResult.Should().NotBeNull();
        createUserResult.Id.Should().Be(sale.Id);
        await _saleRepository.Received(1).AddAsync(Arg.Any<Sale>(), Arg.Any<CancellationToken>());
    }

}
