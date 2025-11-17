using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomy;

public record GetGastronomyQuery(int GastronomyId) : IRequest<GastronomyByIdResponse>;