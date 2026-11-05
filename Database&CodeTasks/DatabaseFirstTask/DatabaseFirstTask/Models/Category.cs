using System;
using System.Collections.Generic;

namespace DatabaseFirstTask.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Cname { get; set; } = null!;

    public string? Cdescription { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
