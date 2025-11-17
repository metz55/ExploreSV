using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Statuses.Commands.UpdateStatus;

internal sealed class UpdateStatusHandler(IEfRepository<Status> _repository)
    : IRequestHandler<UpdateStatusCommand, int>
{
    public async Task<int> Handle(UpdateStatusCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var existingStatus = await _repository.GetByIdAsync(command.Request.StatusId);
            if (existingStatus is null) return 0;
            existingStatus = command.Request.Adapt(existingStatus);
            await _repository.UpdateAsync(existingStatus, cancellationToken);
            return existingStatus.StatusId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}