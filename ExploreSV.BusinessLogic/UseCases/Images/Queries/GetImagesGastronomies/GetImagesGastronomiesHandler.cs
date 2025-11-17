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

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImagesGastronomies;

internal class GetImagesGastronomiesHandler(IEfRepository<Image> _repository)
    : IRequestHandler<GetImagesGastronomiesQuery, List<ImageGastronomyResponse>>
{
    public async Task<List<ImageGastronomyResponse>> Handle(GetImagesGastronomiesQuery query, CancellationToken cancellationToken)
    {
        var images = await _repository.ListAsync(new GetImageByIdSpec(query.TouristDestinationId, query.GastronomyId, query.EventId), cancellationToken);
        if (images == null || !images.Any())
        {
            return new List<ImageGastronomyResponse>();
        }
        return images.Adapt<List<ImageGastronomyResponse>>();
    }
}
