using System.ComponentModel.DataAnnotations;
namespace Commerce.Application.DTOs.Requests;

public class CreateProductRequest
{
    [Required, StringLength(50)]
    public string SKU { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required , StringLength(3, MinimumLength = 3)]
    public string Currency { get; set; }

    [Range(1 , int.MaxValue)]
    public int StockQuantity { get; set; }
}
