using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateEventRequest
    {
        public int TouristDestinationId { get; set; }

        public string? EventTitle { get; set; }

        public string? EventDescription { get; set; }

        public virtual ICollection<CreateImageEventRequest> Images { get; set; } = new List<CreateImageEventRequest>();

    }

    public class UpdateEventRequest
    {
        public int EventId { get; set; }

        public int TouristDestinationId { get; set; }

        public string? EventTitle { get; set; }

        public string? EventDescription { get; set; }
    }

    public class EventResponse
    {
        public int EventId { get; set; }

        public int TouristDestinationId { get; set; }

        public string? EventTitle { get; set; }

        public string? EventDescription { get; set; }

        public string TouristDestinationTitle { get; set; } = null!;

        public virtual ICollection<ImageEventResponse> Images { get; set; } = new List<ImageEventResponse>();

    }
}
