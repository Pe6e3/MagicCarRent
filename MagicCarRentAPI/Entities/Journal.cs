﻿namespace MagicCarRentAPI.Entities;

public class Journal :BaseEntity
{
    public int ClientID { get; set; }
    public int CarID { get; set; }
    public Car? Car { get; set; }
    public Client? Client { get; set; }
    public DateTime? BeginRent { get; set; }
    public DateTime? EndRent { get; set; }
    public Discount? Discount { get; set; }
    public Double RentBill { get; set; }
}
