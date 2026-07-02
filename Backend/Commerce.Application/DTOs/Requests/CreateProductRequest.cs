using System.ComponentModel.DataAnnotations;
namespace Commerce.Application.DTOs.Requests;

public class CreateProductRequest
{
    [Required, StringLength(50)]
    public required string SKU { get; set; }

    [Required, StringLength(200)]
    public required string Name { get; set; }

    [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
    public decimal Price { get; set; }

    [Required, StringLength(3, MinimumLength = 3)]
    public required string Currency { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
}
