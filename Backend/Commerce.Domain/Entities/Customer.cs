using System;
using System.Collections.Generic;
using Commerce.Domain.Common;
using Commerce.Domain.ValueObjects;

namespace Commerce.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public Address? ShippingAddress { get; private set; }
    public Address? BillingAddress { get; private set; }

    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    public Customer(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    protected Customer() { }

    public void SetAddresses(Address shipping, Address billing)
    {
        ShippingAddress = shipping;
        BillingAddress = billing;
    }
}