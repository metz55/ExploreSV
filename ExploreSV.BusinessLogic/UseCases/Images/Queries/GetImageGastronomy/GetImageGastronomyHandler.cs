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

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageGastronomy;

internal sealed class GetImageGastronomyHandler(IEfRepository<Image> _repository) : IRequestHandler<GetImageGastronomyQuery, ImageGastronomyResponse>
{
    public async Task<ImageGastronomyResponse> Handle(GetImageGastronomyQuery query, CancellationToken cancellationToken)
    {
        var image = await _repository.GetByIdAsync(query.GastronomyId, cancellationToken);

        if (image is null)
        {
            return new ImageGastronomyResponse();
        }

        return image.Adapt<ImageGastronomyResponse>();
    }
}

