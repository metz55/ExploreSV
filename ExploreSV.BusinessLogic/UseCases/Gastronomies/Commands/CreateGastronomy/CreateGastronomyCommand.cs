using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.CreateGastronomy;

public record CreateGastronomyCommand(CreateGastronomyRequest Request) : IRequest<int>;