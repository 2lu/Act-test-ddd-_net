using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;
      

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<List<Sale>> GetAllAsync( CancellationToken cancellationToken = default)
    {
        return await _context.Sales.ToListAsync(cancellationToken);
    }

    public async Task<Sale> AddAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default)
    {
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<bool> CancelAsync(int id, CancellationToken cancellationToken = default)
    {
        var sale = await _context.Sales.FindAsync(id);
        if (sale != null)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
   
}
