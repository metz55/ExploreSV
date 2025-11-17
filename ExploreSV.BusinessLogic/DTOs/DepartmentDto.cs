namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateDepartmentRequest
    {
        public string DepartamentName { get; set; } = null!;
    }

    public class DepartmentResponse
    {
        public int DepartmentId { get; set; }
        public string DepartamentName { get; set; } = null!;
    }
}