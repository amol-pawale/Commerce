using System;
using System.Collections.Generic;
using System.Linq;
using Commerce.Domain.Common;
using Commerce.Domain.ValueObjects;

namespace Commerce.Domain.Entities;

// Represents the different stages an order can be in
public enum OrderStatus
{
    Pending,    // Order placed, awaiting payment confirmation
    Confirmed,  // Payment confirmed
    Shipped,    // Order dispatched
    Delivered,  // Customer received the order
    Cancelled   // Order was cancelled
}

public class Order : BaseEntity
{
    public Guid CustomerId { get; private set; }
    public Customer? Customer { get; private set; }

    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    // Snapshot of address at the time of order (customer may change address later)
    public Address ShippingAddress { get; private set; } = null!;

    // Calculated total — kept in sync whenever an item is added
    public Money TotalAmount { get; private set; } = Money.Zero();

    private readonly List<OrderItem> _items = new();
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order(Guid customerId, Address shippingAddress)
    {
        CustomerId = customerId;
        ShippingAddress = shippingAddress;
    }

    // Required by EF Core
    protected Order() { }

    public void AddItem(Guid productId, string productName, Money unitPrice, int quantity)
    {
        var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);
        if (existingItem != null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            _items.Add(new OrderItem(Id, productId, productName, unitPrice, quantity));
        }

        // Recalculate total every time an item is added
        RecalculateTotal();
    }

    public void MarkAsConfirmed()
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException($"Cannot confirm an order in '{Status}' status.");

        Status = OrderStatus.Confirmed;
    }

    public void MarkAsShipped()
    {
        if (Status != OrderStatus.Confirmed)
            throw new InvalidOperationException($"Cannot ship an order in '{Status}' status.");

        Status = OrderStatus.Shipped;
    }

    public void MarkAsDelivered()
    {
        if (Status != OrderStatus.Shipped)
            throw new InvalidOperationException($"Cannot deliver an order in '{Status}' status.");

        Status = OrderStatus.Delivered;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped || Status == OrderStatus.Delivered)
            throw new InvalidOperationException($"Cannot cancel an order that is already '{Status}'.");

        Status = OrderStatus.Cancelled;
    }

    private void RecalculateTotal()
    {
        var totalAmount = _items.Sum(i => i.UnitPrice.Amount * i.Quantity);
        TotalAmount = new Money(totalAmount, TotalAmount.Currency);
    }
}