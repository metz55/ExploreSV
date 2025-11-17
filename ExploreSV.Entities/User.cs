using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string? UserPassword { get; set; }

    public string? UserName { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<TouristDestination> TouristDestinations { get; set; } = new List<TouristDestination>();
}