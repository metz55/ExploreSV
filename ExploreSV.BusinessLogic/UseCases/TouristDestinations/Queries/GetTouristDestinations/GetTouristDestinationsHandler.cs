using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.TouristDestinations.Specifications;
using ExploreSV.BusinessLogic.Utils;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.TouristDestinations.Queries.GetTouristDestinations;

internal sealed class GetTouristDestinationsHandler(IEfRepository<TouristDestination> _repository)
    : IRequestHandler<GetTouristDestinationsQuery, PaginatedList<TouristDestinationResponse>>
{
    public async Task<PaginatedList<TouristDestinationResponse>> Handle(GetTouristDestinationsQuery query, CancellationToken cancellationToken)
    {
        // Obtén el total de elementos (sin paginar)
        var totalItems = await _repository.CountAsync(new GetTouristDestinationWithCategorySpec(), cancellationToken);

        // Obtén los elementos paginados
        var touristDestinations = await _repository.ListAsync(
            new GetTouristDestinationWithCategorySpec(
                skip: (query.PageNumber - 1) * query.PageSize,
                take: query.PageSize,
                TouristDestinationId: 0
            ),
            cancellationToken
        );

        // Si no hay elementos, devuelve una lista vacía paginada
        if (touristDestinations == null || !touristDestinations.Any())
        {
            return new PaginatedList<TouristDestinationResponse>(new List<TouristDestinationResponse>(), 0, query.PageNumber, query.PageSize);
        }

        // Convierte a DTO y devuelve el objeto paginado
        var touristDestinationResponses = touristDestinations.Adapt<List<TouristDestinationResponse>>();
        return new PaginatedList<TouristDestinationResponse>(touristDestinationResponses, totalItems, query.PageNumber, query.PageSize);

    }
}