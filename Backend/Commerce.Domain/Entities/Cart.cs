using System;
using System.Collections.Generic;
using System.Linq;
using Commerce.Domain.Common;

namespace Commerce.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid? CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    private readonly List<CartItem> _items = new();
    public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

    public Cart(Guid? customerId = null)
    {
        CustomerId = customerId;
    }

    protected Cart() { }

    public void AddItem(Guid productId, int quantity)
    {
        var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            _items.Add(new CartItem(Id, productId, quantity));
        }
    }

    public void RemoveItem(Guid productId)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
}