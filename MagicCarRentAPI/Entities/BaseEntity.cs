using System.ComponentModel.DataAnnotations;

namespace MagicCarRentAPI.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
