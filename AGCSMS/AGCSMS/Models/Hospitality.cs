using System;
using System.Collections.Generic;

namespace AGCSMS.Models;

public partial class Hospitality
{
    public int Id { get; set; }

    public string? SupplierName { get; set; }

    public string? OfferName { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }
}
