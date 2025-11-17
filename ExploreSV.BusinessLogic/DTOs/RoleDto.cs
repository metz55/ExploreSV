namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateRoleRequest
    {
        public string RoleName { get; set; } = null!;
    }


    public class RoleResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }

}