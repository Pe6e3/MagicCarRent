using System.ComponentModel.DataAnnotations;

namespace MagicCarRentAPI.Entities.DTO;

public class CarDTO : BaseEntity
{
    [Display(Name = "Модель")][MaxLength(20)] public string? Model { get; set; }
    [Display(Name = "Марка")][MaxLength(20)] public string? Brand { get; set; }

    [Range(1950, 2024, ErrorMessage = "Год выпуска должен быть в диапазоне от 1950 до 2024")]
    [Display(Name = "Год выпуска")] public int Year { get; set; }
    [Display(Name = "Цвет")] public Car.Color? CarColor { get; set; }
    [Display(Name = "Стоимость часа")] public double CostHour { get; set; }
    [Display(Name = "Стоимость суток")] public double CostDay { get; set; }
    [Display(Name = "Итого часов было в прокате")] public double TotalRentTime { get; set; }
    [Display(Name = "Итого денег заработано машиной")] public double TotalMoneyEarn { get; set; }
    [Display(Name = "В аренде сейчас")] public bool IsRentedNow { get; set; }
    [Display(Name = "В ремонте сейчас")] public bool IsInService { get; set; }
}
