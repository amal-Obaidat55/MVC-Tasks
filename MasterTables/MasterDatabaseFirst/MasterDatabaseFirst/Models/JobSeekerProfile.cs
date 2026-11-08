using System;
using System.Collections.Generic;

namespace MasterDatabaseFirst.Models;

public partial class JobSeekerProfile
{
    public int UserId { get; set; }

    public string? Headline { get; set; }

    public string? Location { get; set; }

    public string? Summary { get; set; }

    public decimal? YearsExperience { get; set; }

    public string? LinkedInUrl { get; set; }

    public string? PortfolioUrl { get; set; }

    public string? DesiredRole { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
