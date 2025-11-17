using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Images.Commands.DeleteImage;

internal sealed class DeleteImageEventHandler(IEfRepository<Image> _repository)
    : IRequestHandler<DeleteImageEventCommand, int>
{
    public async Task<int> Handle(DeleteImageEventCommand command, CancellationToken cancellationToken)
    {
        var existingImage = await _repository.GetByIdAsync(command.ImageId);
        if (existingImage is null) return 0;
        await _repository.DeleteAsync(existingImage, cancellationToken);
        return existingImage.ImageId;
    }
}

