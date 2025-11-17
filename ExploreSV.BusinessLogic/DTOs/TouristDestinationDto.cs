using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateTouristDestinationRequest
    {
        public int StatusId { get; set; }

        public int CategoryId { get; set; }

        public int DepartmentId { get; set; }

        public int UserId { get; set; }

        public string TouristDestinationTitle { get; set; } = null!;

        public string TouristDestinationDescription { get; set; } = null!;

        public string TouristDestinationLocation { get; set; } = null!;

        public string TouristDestinationSchedule { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; } = new List<Event>();

        public virtual ICollection<Gastronomy> Gastronomies { get; set; } = new List<Gastronomy>();

        public virtual ICollection<CreateImageTouristDestinationRequest> Images { get; set; } = new List<CreateImageTouristDestinationRequest>();
    }

    public class UpdateTouristDestinationRequest
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

        public virtual ICollection<CreateImageTouristDestinationRequest> Images { get; set; } = new List<CreateImageTouristDestinationRequest>();
    }

    public class TouristDestinationResponse
    {
        public int TouristDestinationId { get; set; }

        public string TouristDestinationTitle { get; set; } = null!;

        public string TouristDestinationDescription { get; set; } = null!;

        public string TouristDestinationLocation { get; set; } = null!;

        public string TouristDestinationSchedule { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string DepartamentName { get; set; } = null!;

        public virtual ICollection<EventResponse> Events { get; set; } = new List<EventResponse>();

        public virtual ICollection<GastronomyResponse> Gastronomies { get; set; } = new List<GastronomyResponse>();

        public virtual ICollection<ImageTouristDestinationResponse> Images { get; set; } = new List<ImageTouristDestinationResponse>();
    }

    public class TouristDestinationByIdResponse
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

        public string CategoryName { get; set; } = null!;

        public string DepartamentName { get; set; } = null!;

        public virtual ICollection<EventResponse> Events { get; set; } = new List<EventResponse>();

        public virtual ICollection<GastronomyResponse> Gastronomies { get; set; } = new List<GastronomyResponse>();

        public virtual ICollection<ImageTouristDestinationResponse> Images { get; set; } = new List<ImageTouristDestinationResponse>();
    }
}
