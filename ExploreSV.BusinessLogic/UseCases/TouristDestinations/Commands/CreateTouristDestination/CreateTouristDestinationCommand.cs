using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Commands.CreateTouristDestination;

public record CreateTouristDestinationCommand(CreateTouristDestinationRequest Request) : IRequest<int>;