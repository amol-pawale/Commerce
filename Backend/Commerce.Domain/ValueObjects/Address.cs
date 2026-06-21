namespace Commerce.Domain.ValueObjects;

public record Address(
    string Street,
    string City,
    string State,
    string Zipcode,
    string Country
);