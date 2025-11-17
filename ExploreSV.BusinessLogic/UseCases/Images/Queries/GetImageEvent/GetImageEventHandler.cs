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

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageEvent;

internal sealed class GetImageEventHandler(IEfRepository<Image> _repository) : IRequestHandler<GetImageEventQuery, ImageEventResponse>
{
    public async Task<ImageEventResponse> Handle(GetImageEventQuery query, CancellationToken cancellationToken)
    {
        var image = await _repository.GetByIdAsync(query.EventId, cancellationToken);

        if (image is null)
        {
            return new ImageEventResponse();
        }

        return image.Adapt<ImageEventResponse>();
    }
}

