using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Commands.UpdateTouristDestination;

public record UpdateTouristDestinationCommand(UpdateTouristDestinationRequest Request) : IRequest<int>;