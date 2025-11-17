using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestination;

public record GetTouristDestinationQuery(int TouristDestinationId) : IRequest<TouristDestinationByIdResponse>;