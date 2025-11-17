namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateGastronomyRequest
    {
        public int TouristDestinationId { get; set; }

        public string? GastronomyTitle { get; set; }

        public string? GastronomyDescription { get; set; }

        public virtual ICollection<CreateImageGastronomyRequest> Images { get; set; } = new List<CreateImageGastronomyRequest>();
    }

    public class UpdateGastronomyRequest
    {
        public int GastronomyId { get; set; }

        public int TouristDestinationId { get; set; }

        public string? GastronomyTitle { get; set; }

        public string? GastronomyDescription { get; set; }

        public virtual ICollection<CreateImageGastronomyRequest> Images { get; set; } = new List<CreateImageGastronomyRequest>();
    }

    public class GastronomyResponse
    {
        public int GastronomyId { get; set; }

        public int TouristDestinationId { get; set; }

        public string? GastronomyTitle { get; set; }

        public string? GastronomyDescription { get; set; }

        public string TouristDestinationTitle { get; set; } = null!; //Se hace su Specification y Mapping

        public virtual ICollection<ImageGastronomyResponse> Images { get; set; } = new List<ImageGastronomyResponse>();
    }

    public class GastronomyByIdResponse
    {
        public int GastronomyId { get; set; }

        public int TouristDestinationId { get; set; }

        public string? GastronomyTitle { get; set; }

        public string? GastronomyDescription { get; set; }

        public string TouristDestinationTitle { get; set; } = null!; //Sirve para obtener el title en el controller get id

    }
}