using System;
using Commerce.Domain.Common;
using Commerce.Domain.ValueObjects;

namespace Commerce.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }

    // Snapshot of product name at time of order
    // (product name may change in catalog later, but order history must stay accurate)
    public string ProductName { get; private set; } = string.Empty;

    // Snapshot of price at time of order
    // (price may change in catalog later, but order must retain the price customer paid)
    public Money UnitPrice { get; private set; } = null!;

    public int Quantity { get; private set; }

    // Calculated convenience property — total for this line item
    public Money LineTotal => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);

    internal OrderItem(Guid orderId, Guid productId, string productName, Money unitPrice, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    // Required by EF Core
    protected OrderItem() { }

    // Only Order (same assembly) can call this — keeps control inside the aggregate
    internal void IncreaseQuantity(int amount)
    {
        Quantity += amount;
    }
}