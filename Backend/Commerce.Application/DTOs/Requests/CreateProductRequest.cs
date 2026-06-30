namespace Commerce.Application.DTOs.Requests;

public class CreateProductRequest
{
    public string SKU { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; }

    public int StockQuantity { get; set; }
}
