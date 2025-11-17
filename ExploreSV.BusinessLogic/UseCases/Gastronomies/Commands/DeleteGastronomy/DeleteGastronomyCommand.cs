using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Commands.DeleteGastronomy;

public record DeleteGastronomyCommand(int GastronomyId) : IRequest<int>;