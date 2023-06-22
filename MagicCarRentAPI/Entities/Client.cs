namespace MagicCarRentAPI.Entities;

public class Client :BaseEntity
{
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? FullName => $"{Name} {Lastname}";
    public double TotalBill { get; set; }
    public double TotalPay { get; set; }
    public double TotalDebt { get; set; }
    public double TotalDrivingTime { get; set; }
    public double Experience { get; set; }
    public double Score { get; set; }
}
