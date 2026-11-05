using System;
using System.Collections.Generic;

namespace DatabaseFirstTask.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Pname { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? Cid { get; set; }

    public int? SuppId { get; set; }

    public virtual Category? CidNavigation { get; set; }

    public virtual ICollection<PurchaseOrderItem> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItem>();

    public virtual Supplier? Supp { get; set; }
}
