using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.DTOs
{

    /// 
    /// <Destinos>
    public class CreateImageTouristDestinationRequest
    {
        public int? TouristDestinationId { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class ImageTouristDestinationResponse
    {
        public int? TouristDestinationId { get; set; }

        public string? ImageUrl { get; set; }
    }

    /// 
    /// <gastronomia>

    public class CreateImageGastronomyRequest
    {
        public int? GastronomyId { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class ImageGastronomyResponse
    {
        public int? GastronomyId { get; set; }

        public string? ImageUrl { get; set; }
    }

    
    /// 
    /// <Eventos>

    public class CreateImageEventRequest
    {
        public int? EventId { get; set; }

        public string? ImageUrl { get; set; }


    }

    public class ImageEventResponse
    {


        public int? EventId { get; set; }

        public string? ImageUrl { get; set; }

    }


}
