using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.Utils;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestinations;

public record GetTouristDestinationsQuery() : IRequest<PaginatedList<TouristDestinationResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 6;
}