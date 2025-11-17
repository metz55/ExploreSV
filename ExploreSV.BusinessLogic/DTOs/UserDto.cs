namespace ExploreSV.BusinessLogic.DTOs
{
    public class CreateUserRequest
    {
        public int RoleId { get; set; }

        public string? UserPassword { get; set; }

        public string? UserName { get; set; }
    }

    public class UserResponse
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string? UserPassword { get; set; }

        public string? UserName { get; set; }

        public string? RoleName { get; set; }
    }
}