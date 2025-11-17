using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Commands.DeleteImage;
public record DeleteImageGastronomyCommand(int ImageId) : IRequest<int>;
