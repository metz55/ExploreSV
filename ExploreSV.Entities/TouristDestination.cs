using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class TouristDestination
{
    public int TouristDestinationId { get; set; }

    public int StatusId { get; set; }

    public int CategoryId { get; set; }

    public int DepartmentId { get; set; }

    public int UserId { get; set; }

    public string TouristDestinationTitle { get; set; } = null!;

    public string TouristDestinationDescription { get; set; } = null!;

    public string TouristDestinationLocation { get; set; } = null!;

    public string TouristDestinationSchedule { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Gastronomy> Gastronomies { get; set; } = new List<Gastronomy>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual Status Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}