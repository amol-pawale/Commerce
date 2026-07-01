using Commerce.Application.DTOs.Common;
using Commerce.Domain.Entities;

namespace Commerce.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync(PagedRequest pagedRequest ,  CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id , CancellationToken cancellationToken = default);

    Task AddAsync(Product product,  CancellationToken cancellationToken = default);

    Task UpdateAsync(Product product,  CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id ,  CancellationToken cancellationToken = default);
}