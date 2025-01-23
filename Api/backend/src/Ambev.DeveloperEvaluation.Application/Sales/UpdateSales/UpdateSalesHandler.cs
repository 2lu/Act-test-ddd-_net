using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Sale>
    {
        private readonly ISaleRepository _saleRepository;

        public UpdateSaleCommandHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = new Sale
            {
                Id = request.Id,
                Date = request.Date,
                CustomerId = request.CustomerId,
                TotalSaleAmount = request.TotalSaleAmount,
                Branch = request.Branch,
                Items = request.Items.Select(i => new SaleItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Discount = i.Discount
                }).ToList(),
                IsCancelled = false
            };

            return await _saleRepository.UpdateAsync(sale);
        }
    }
}