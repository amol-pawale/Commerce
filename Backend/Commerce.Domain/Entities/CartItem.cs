using System;
using Commerce.Domain.Common;

namespace Commerce.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid CartId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public Product? Product { get; private set; }

    internal CartItem(Guid cartId, Guid productId, int quantity)
    {
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
    }

    protected CartItem() { }

    internal void IncreaseQuantity(int amount)
    {
        Quantity += amount;
    }
}