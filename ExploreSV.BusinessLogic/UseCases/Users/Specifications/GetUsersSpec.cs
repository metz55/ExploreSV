using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.Users.Specifications
{
    public class GetUsersSpec : Specification<User>
    {
        public GetUsersSpec()
        {
            // Ordena los usuarios por nombre de usuario
            Query.OrderBy(u => u.UserName);
            // Incluye el rol si es necesario
            Query.Include(u => u.Role);
        }

        public GetUsersSpec(int skip, int take)
            : this() // Llama al constructor original
        {
            // Aplica paginación
            Query.Skip(skip).Take(take);
        }
    }
}