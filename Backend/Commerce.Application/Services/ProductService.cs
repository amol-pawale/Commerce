using Commerce.Application.DTOs.Responses;
using Commerce.Application.Interfaces;
using Commerce.Application.DTOs.Common;

namespace Commerce.Application.Services;

using System.Linq;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<PagedResult<ProductResponse>> GetAllAsync(PagedRequest pagedRequest, CancellationToken cancellationToken = default)
    {
        var products = await _repository.GetAllAsync(pagedRequest, cancellationToken);
        return new PagedResult<ProductResponse>
        {
            Items = products.Items.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                SKU = product.SKU,
                Price = product.Price.Amount,
                Currency = product.Price.Currency,
                StockQuantity = product.StockQuantity

            }).ToList(),
            PageNumber = products.PageNumber,
            PageSize = products.PageSize,
            TotalCount = products.TotalCount
        };
    }
}