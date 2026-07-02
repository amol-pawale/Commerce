namespace Commerce.Application.DTOs.Responses;

public class ProductResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string SKU { get; set; }
    public required string Currency { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}