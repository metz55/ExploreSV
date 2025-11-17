using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestination;

internal sealed class GetTouristDestinationHandler(IEfRepository<TouristDestination> _repository)
    : IRequestHandler<GetTouristDestinationQuery, TouristDestinationByIdResponse>
{
    public async Task<TouristDestinationByIdResponse> Handle(GetTouristDestinationQuery query, CancellationToken cancellationToken)
    {
        var touristDestination = await _repository.FirstOrDefaultAsync(new GetTouristDestinationWithCategorySpec(query.TouristDestinationId), cancellationToken);

        if (touristDestination is null)
        {
            return new TouristDestinationByIdResponse();
        }

        return touristDestination.Adapt<TouristDestinationByIdResponse>();
    }
}