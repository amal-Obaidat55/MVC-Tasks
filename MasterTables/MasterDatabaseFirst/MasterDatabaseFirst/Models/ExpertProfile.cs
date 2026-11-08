using System;
using System.Collections.Generic;

namespace MasterDatabaseFirst.Models;

public partial class ExpertProfile
{
    public int UserId { get; set; }

    public string? Headline { get; set; }

    public string? Bio { get; set; }

    public string? Organization { get; set; }

    public string? Location { get; set; }

    public int? YearsExperience { get; set; }

    public decimal? HourlyRate { get; set; }

    public string Currency { get; set; } = null!;

    public bool IsListed { get; set; }

    public virtual User User { get; set; } = null!;
}
