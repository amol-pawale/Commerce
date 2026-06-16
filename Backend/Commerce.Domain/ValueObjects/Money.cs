namespace Commerce.Domain.ValueObjects;
//C# records are perfect for the Value objects as they provide stuctural quantity out of the box 

public record Money(decimal Amount, string Currency)
{
    public static Money Zero(string currency = "USD") => new(0, currency);
}