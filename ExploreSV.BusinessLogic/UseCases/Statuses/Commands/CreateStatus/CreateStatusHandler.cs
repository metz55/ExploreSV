using ExploreSV.BusinessLogic.UseCases.Categories.Commands.CreateCategory;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Statuses.Commands.CreateStatus;

internal sealed class CreateStatusHandler(IEfRepository<Status> _repository)
    : IRequestHandler<CreateStatusCommand, int>
{
    public async Task<int> Handle(CreateStatusCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newStatus = command.Request.Adapt<Status>();
            var createStatus = await _repository.AddAsync(newStatus, cancellationToken);
            return createStatus.StatusId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
