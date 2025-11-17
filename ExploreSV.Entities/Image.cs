using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class Image
{
    public int ImageId { get; set; }

    public int? TouristDestinationId { get; set; }

    public int? GastronomyId { get; set; }

    public int? EventId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Gastronomy? Gastronomy { get; set; }

    public virtual TouristDestination? TouristDestination { get; set; }
}
