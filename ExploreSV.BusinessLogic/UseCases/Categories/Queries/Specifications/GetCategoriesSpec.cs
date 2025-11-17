using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.Categories.Queries.Specifications
{
    public class GetCategoriesSpec : Specification<Category>
    {
        public GetCategoriesSpec(int CategoryId = 0)
        {
            if (CategoryId > 0)
                Query.Where(c => c.CategoryId == CategoryId);

            // Ordena las categorías por nombre
            Query.OrderBy(c => c.CategoryName);
        }

        public GetCategoriesSpec(int skip, int take, int CategoryId = 0)
            : this(CategoryId) // Llama al constructor original
        {
            // Aplica paginación
            Query.Skip(skip).Take(take);
        }
    }
}