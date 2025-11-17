using ExploreSV.BusinessLogic.UseCases.Categories.Commands.DeleteCategory;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Statuses.Commands.DeleteStatus;

internal sealed class DeleteStatusHandler(IEfRepository<Status> _repository)
    : IRequestHandler<DeleteStatusCommand, int>
{
    public async Task<int> Handle(DeleteStatusCommand command, CancellationToken cancellationToken)
    {
        var existingStatus = await _repository.GetByIdAsync(command.statusId);
        if (existingStatus is null) return 0;
        await _repository.DeleteAsync(existingStatus, cancellationToken);
        return existingStatus.StatusId;
    }
}
