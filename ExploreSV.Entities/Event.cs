using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class Event
{
    public int EventId { get; set; }

    public int TouristDestinationId { get; set; }

    public string? EventTitle { get; set; }

    public string? EventDescription { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual TouristDestination TouristDestination { get; set; } = null!;
}
