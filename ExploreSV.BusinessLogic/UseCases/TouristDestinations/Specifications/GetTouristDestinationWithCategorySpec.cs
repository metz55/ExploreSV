using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Specifications
{
    public class GetTouristDestinationWithCategorySpec : Specification<TouristDestination>
    {
        public GetTouristDestinationWithCategorySpec(int TouristDestinationId = 0) 
        {
            if (TouristDestinationId > 0)
                Query.Where(i => i.TouristDestinationId == TouristDestinationId);

            Query.Include(td => td.Category);

            Query.Include(td => td.Department);

            Query.Include(td => td.Events);

            Query.Include(td => td.Gastronomies);

            Query.Include(td => td.Images);
        }

        public GetTouristDestinationWithCategorySpec(int skip, int take, int TouristDestinationId = 0)
            : this(TouristDestinationId) // Llama al constructor original
        {
            Query.Skip(skip).Take(take);
        }
    }
}