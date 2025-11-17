using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class Status
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<TouristDestination> TouristDestinations { get; set; } = new List<TouristDestination>();
}
