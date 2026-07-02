using Commerce.Application.DTOs.Common;
using Commerce.Application.DTOs.Responses;

namespace Commerce.Application.Interfaces;

public interface IProductService
{
    Task<PagedResult<ProductResponse>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken = default);
}
