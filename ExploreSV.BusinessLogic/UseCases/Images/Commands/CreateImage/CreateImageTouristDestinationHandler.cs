using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Commands.CreateImage;
internal sealed class CreateImageTouristDestinationHandler(IEfRepository<Image> _repository) : IRequestHandler<CreateImageTouristDestinationCommand, int>
{
    public async Task<int> Handle(CreateImageTouristDestinationCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newImage = command.Request.Adapt<Image>();

            var createImage = await _repository.AddAsync(newImage, cancellationToken);
            return createImage.ImageId;

        }

        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
