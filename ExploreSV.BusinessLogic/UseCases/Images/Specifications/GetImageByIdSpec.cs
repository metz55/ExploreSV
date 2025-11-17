using Ardalis.Specification;
using ExploreSV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Specifications
{
    public class GetImageByIdSpec : Specification<Image>
    {
        public GetImageByIdSpec(int TouristDestinationId, int GastronomyId, int EventId) {
            
            Query.Where(i => i.TouristDestinationId == TouristDestinationId);

            Query.Where(i => i.GastronomyId == GastronomyId);

            Query.Where(i => i.EventId == EventId);

        }
    }
}
