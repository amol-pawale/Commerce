using System;
using Commerce.Domain.Common;
using Commerce.Domain.ValueObjects;

namespace Commerce.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string SKU { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Money Price { get; private set; } = null!;
    public int StockQuantity { get; private set; }
    public Guid CategoryId { get; private set; }

    public Category? Category { get; private set; }

    public Product(string name, string sku, Money price, int stockQuantity, Guid categoryId, string? description = null)
    {
        Name = name;
        SKU = sku;
        Price = price;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
        Description = description;
    }

    protected Product() { }

    public void UpdateStock(int quantity)
    {
        StockQuantity += quantity;
    }
}