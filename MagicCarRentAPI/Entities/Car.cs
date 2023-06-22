namespace MagicCarRentAPI.Entities;

public class Car : BaseEntity
{
    public string? Model { get; set; }
    public string? Brand { get; set; }
    public string ModelAndBrand => $"{Brand} {Model}";

    public int Year { get; set; }
    public Color? CarColor { get; set; }
    public double CostHour { get; set; }
    public double CostDay { get; set; }
    public double TotalRentTime { get; set; }
    public double TotalMoneyEarn { get; set; }
    public bool IsRentedNow { get; set; }
    public bool IsInService { get; set; }

    public enum Color
    {
        Black,
        White,
        Red,
        Yellow,
        Blue,
        Green,
        Gray,
        OtherColor
    };
}