using System;
using System.Collections.Generic;

namespace MasterDatabaseFirst.Models;

public partial class UserSetting
{
    public int UserId { get; set; }

    public string Theme { get; set; } = null!;

    public string LanguageCode { get; set; } = null!;

    public bool EmailNotifications { get; set; }

    public bool PushNotifications { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
