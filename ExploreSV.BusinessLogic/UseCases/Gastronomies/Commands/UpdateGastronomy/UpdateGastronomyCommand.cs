using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.UpdateGastronomy;

public record UpdateGastronomyCommand(UpdateGastronomyRequest Request) : IRequest<int>;