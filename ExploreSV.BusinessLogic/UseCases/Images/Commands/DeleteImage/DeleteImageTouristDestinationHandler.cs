using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Commands.DeleteImage;
internal class DeleteImageTouristDestinationHandler(IEfRepository<Image> _repository)
    : IRequestHandler<DeleteImageTouristDestinationCommand, int>
{
    public async Task<int> Handle(DeleteImageTouristDestinationCommand command, CancellationToken cancellationToken)
    {
        var existingImage = await _repository.GetByIdAsync(command.ImageId);
        if (existingImage is null) return 0;
        await _repository.DeleteAsync(existingImage, cancellationToken);
        return existingImage.ImageId;
    }
}
