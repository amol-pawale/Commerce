using MediatR;
using Commerce.Application.Interfaces;
using Commerce.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Commerce.Application.Features.Products.Queries.GetBadProducts;

public class GetBadProductsHandler : IRequestHandler<GetBadProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICartRepository _cartRepository;

    public GetBadProductsHandler(IProductRepository productRepository, ICartRepository cartRepository)
    {
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }

    public async Task<List<ProductDto>> Handle(GetBadProductsQuery request, CancellationToken ct)
    {
        try
        {
            // BAD PRACTICE 1: Blocking on async code instead of awaiting it.
            // Your Gemini prompt says: "Proper async/await usage (avoiding .Result, .Wait()...)"
            var products = _productRepository.GetAllAsync(ct).Result; 

            // BAD PRACTICE 2: N+1 Query problem simulation.
            // Your Gemini prompt says: "Efficient Entity Framework (EF) Core queries (look for N+1 query problems...)"
            foreach (var p in products)
            {
                // Hitting the database inside a loop for every single product!
                // Also using .GetAwaiter().GetResult() which blocks the thread.
                var relatedCart = _cartRepository.GetByIdAsync(p.Id, ct).GetAwaiter().GetResult();
            }

            return products.Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.SKU,
                p.Description,
                p.Price.Amount,
                p.Price.Currency,
                p.StockQuantity,
                p.CategoryId
            )).ToList();
        }
        catch (Exception ex)
        {
            // BAD PRACTICE 3: Swallowing exceptions without logging.
            // Your Gemini prompt says: "Robust exception handling and structured logging patterns."
            return new List<ProductDto>(); 
        }
    }
}
