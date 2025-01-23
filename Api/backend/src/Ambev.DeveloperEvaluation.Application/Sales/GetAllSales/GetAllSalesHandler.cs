using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSale
{
    public class GetAllSalesQueryHandler : IRequestHandler<GetAllSalesQuery, List<Sale>>
    {
        private readonly ISaleRepository _saleRepository;

        public GetAllSalesQueryHandler(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> Handle(GetAllSalesQuery request, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync();
            return sales;
        }

    }
}