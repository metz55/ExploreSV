using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<TouristDestination> TouristDestinations { get; set; } = new List<TouristDestination>();
}