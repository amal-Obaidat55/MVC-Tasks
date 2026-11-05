using System;
using System.Collections.Generic;

namespace DatabaseFirstTask.Models;

public partial class PurchaseOrderItem
{
    public int Id { get; set; }

    public int? PurchId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public decimal? UnitPrice { get; set; }

    public virtual Product? Product { get; set; }

    public virtual PurchaseOrder? Purch { get; set; }
}
