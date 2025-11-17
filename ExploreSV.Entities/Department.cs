using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartamentName { get; set; } = null!;

    public virtual ICollection<TouristDestination> TouristDestinations { get; set; } = new List<TouristDestination>();
}