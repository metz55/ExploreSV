using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomies;

public record GetGastronomiesQuery() : IRequest<List<GastronomyResponse>>;