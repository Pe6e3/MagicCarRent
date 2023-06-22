using System.ComponentModel.DataAnnotations;

namespace MagicCarRentAPI.Entities.DTO;

public class JournalDTO : BaseEntity
{

    [Display(Name = "Стоимость часа")] public double CostHour { get; set; }
    [Display(Name = "Стоимость суток")] public double CostDay { get; set; }


    [Display(Name = "Клиент")] public int ClientID { get; set; }
    [Display(Name = "Машина")] public int CarID { get; set; }
    [Display(Name = "Машина")] public Car? Car { get; set; }
    [Display(Name = "Клиент")] public Client? Client { get; set; }
    [Display(Name = "Начало аренды")] public DateTime? BeginRent { get; set; }
    [Display(Name = "Окончание аренды")] public DateTime? EndRent { get; set; }
    [Display(Name = "Итоговая стоимость аренды")] public Double RentBill { get; set; }
    [Display(Name = "Скидка (Название)")] public string? DiscountName { get; set; }
    [Display(Name = "Скидка (размер)")] public double DiscountRate { get; set; }
}
