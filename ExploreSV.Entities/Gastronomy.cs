using System;
using System.Collections.Generic;

namespace ExploreSV.Entities;

public partial class Gastronomy
{
    public int GastronomyId { get; set; }

    public int TouristDestinationId { get; set; }

    public string? GastronomyTitle { get; set; }

    public string? GastronomyDescription { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>(); //Evento

    public virtual TouristDestination TouristDestination { get; set; } = null!; //Llave
}
