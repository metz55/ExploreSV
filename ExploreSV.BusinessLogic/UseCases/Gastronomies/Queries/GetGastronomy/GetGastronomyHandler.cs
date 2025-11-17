using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Gastronomies.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Gastronomies.Queries.GetGastronomy;

internal sealed class GetGastronomyHandler(IEfRepository<Gastronomy> _repository)
    : IRequestHandler<GetGastronomyQuery, GastronomyByIdResponse>
{
    public async Task<GastronomyByIdResponse> Handle(GetGastronomyQuery query, CancellationToken cancellationToken)
    {
        var gastronomy = await _repository.FirstOrDefaultAsync(new GetGastronomyWithTouristDestinationSpec(query.GastronomyId), cancellationToken);

        if (gastronomy is null)
        {
            return new GastronomyByIdResponse();
        }

        return gastronomy.Adapt<GastronomyByIdResponse>();
    }
}