using System;
using System.Collections.Generic;

namespace Task6p2.Models;

public partial class Order1
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Ostatus { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
