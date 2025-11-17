using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomies;

internal sealed class GetGastronomiesHandler(IEfRepository<Gastronomy> _repository)
    : IRequestHandler<GetGastronomiesQuery, List<GastronomyResponse>>
{
    public async Task<List<GastronomyResponse>> Handle(GetGastronomiesQuery query, CancellationToken cancellationToken)
    {

        var gastronomies = await _repository.ListAsync(new GetGastronomyWithTouristDestinationSpec(), cancellationToken);

        if (gastronomies == null && !gastronomies.Any())
        {
            return new List<GastronomyResponse>();
        }

        return gastronomies.Adapt<List<GastronomyResponse>>();
    }
}