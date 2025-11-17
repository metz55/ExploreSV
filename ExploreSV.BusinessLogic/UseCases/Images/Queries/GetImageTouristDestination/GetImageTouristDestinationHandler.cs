using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.DataAccess.Interfaces;
using Mapster;
using MediatR;
using ExploreSV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExploreSV.BusinessLogic.UseCases.Images.Specifications;

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageTouristDestination;

internal sealed class GetImageTouristDestinationHandler(IEfRepository<Image> _repository) : IRequestHandler<GetImageTouristDestinationQuery, ImageTouristDestinationResponse>
{
    public async Task<ImageTouristDestinationResponse> Handle(GetImageTouristDestinationQuery query, CancellationToken cancellationToken)
    {
        var image = await _repository.GetByIdAsync(query.TouristDestinationId, cancellationToken);

        if (image is null)
        {
            return new ImageTouristDestinationResponse();
        }

        return image.Adapt<ImageTouristDestinationResponse>();
    }
}

