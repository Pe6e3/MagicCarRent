namespace MagicCarRentAPI.Entities; 

public class Tax : BaseEntity
{
    public string? TaxName { get; set; }
    public double TaxRate { get; set; }
}
