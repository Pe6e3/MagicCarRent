using System.ComponentModel.DataAnnotations;

namespace MagicCarRentAPI.Entities.DTO;

public class ClientDTO : BaseEntity
{
    [Display(Name = "Имя")][MaxLength(50)] public string? Name { get; set; }

    [Display(Name = "Фамилия")][MaxLength(50)] public string? Lastname { get; set; }

    [Display(Name = "Общая сумма счета")] public double TotalBill { get; set; }

    [Display(Name = "Всего оплачено")] public double TotalPay { get; set; }

    [Display(Name = "Общая задолженность")] public double TotalDebt { get; set; }

    [Display(Name = "Общее время вождения")] public double TotalDrivingTime { get; set; }

    [Display(Name = "Опыт")] public double Experience { get; set; }

    [Display(Name = "Оценка")] public double Score { get; set; }
}
