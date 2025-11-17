using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.Users.Specifications
{
    public class GetUserAuthenticatedSpec : Specification<User>
    {
        public GetUserAuthenticatedSpec(string userName, string userPassword)
        {
            Query.Where(u => u.UserName == userName && u.UserPassword == userPassword);

            Query.Include(u => u.Role);
        }
    }
}