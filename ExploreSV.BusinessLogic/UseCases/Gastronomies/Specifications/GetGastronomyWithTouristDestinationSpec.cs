using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Specifications
{
    public class GetGastronomyWithTouristDestinationSpec : Specification<Gastronomy>
    {
        public GetGastronomyWithTouristDestinationSpec(int id = 0)
        {
            if (id > 0)
                Query.Where(td => td.GastronomyId == id);

            Query.Include(td => td.TouristDestination);
        }
    }

}
