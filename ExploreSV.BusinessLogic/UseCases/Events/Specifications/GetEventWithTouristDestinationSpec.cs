using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.Events.Specifications
{
    public class GetEventWithTouristDestinationSpec : Specification<Event>
    {
        public GetEventWithTouristDestinationSpec()
        {
            Query.Include(td => td.TouristDestination);
        }
    }
}