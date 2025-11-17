using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImagesGastronomies;
public record GetImagesGastronomiesQuery(int TouristDestinationId, int GastronomyId, int EventId) : IRequest<List<ImageGastronomyResponse>>;

