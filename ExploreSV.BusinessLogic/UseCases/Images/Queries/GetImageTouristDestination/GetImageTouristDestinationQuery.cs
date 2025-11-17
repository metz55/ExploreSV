using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Queries.GetImageTouristDestination;
public record GetImageTouristDestinationQuery(int TouristDestinationId) : IRequest<ImageTouristDestinationResponse>;

