using MediatR;
using Commerce.Application.Features.Products.DTOs;

namespace Commerce.Application.Features.Products.Queries.GetBadProducts;

// This query is deliberately built to test the Gemini GitHub Action
public record GetBadProductsQuery() : IRequest<List<ProductDto>>;
