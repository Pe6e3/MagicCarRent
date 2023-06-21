namespace MagicCarRentAPI.Entities; 

public class Discount : BaseEntity
{
    public string? DiscountName { get; set; }
    public double DiscountRate { get; set; }
}
