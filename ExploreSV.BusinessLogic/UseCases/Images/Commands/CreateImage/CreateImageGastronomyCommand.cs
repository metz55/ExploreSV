using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Commands.CreateImage;

public record CreateImageGastronomyCommand(CreateImageGastronomyRequest Request) : IRequest<int>;

