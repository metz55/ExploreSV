using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Images.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImagesTouristDestinations;

internal class GetImagesTouristDestinationsHandler(IEfRepository<Image> _repository)
    : IRequestHandler<GetImagesTouristDestinationsQuery, List<ImageTouristDestinationResponse>>
{
    public async Task<List<ImageTouristDestinationResponse>> Handle(GetImagesTouristDestinationsQuery query, CancellationToken cancellationToken)
    {
        var images = await _repository.ListAsync(new GetImageByIdSpec(query.TouristDestinationId, query.GastronomyId, query.EventId), cancellationToken);
        if (images == null || !images.Any())
        {
            return new List<ImageTouristDestinationResponse>();
        }
        return images.Adapt<List<ImageTouristDestinationResponse>>();
    }
}

