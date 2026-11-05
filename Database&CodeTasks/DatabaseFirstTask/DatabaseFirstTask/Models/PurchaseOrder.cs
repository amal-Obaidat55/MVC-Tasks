using System;
using System.Collections.Generic;

namespace DatabaseFirstTask.Models;

public partial class PurchaseOrder
{
    public int Id { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? Pstatus { get; set; }

    public int? SuppId { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual Supplier? Supp { get; set; }
}
