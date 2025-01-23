using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for User entity operations
/// </summary>
public interface ISaleRepository
{

    Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Sale> AddAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
    Task<bool> CancelAsync(int id, CancellationToken cancellationToken = default);

}
