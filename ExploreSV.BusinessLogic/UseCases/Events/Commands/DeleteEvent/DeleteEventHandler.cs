using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Events.Commands.DeleteEvent;

internal sealed class DeleteEventHandler(IEfRepository<Event> _repository)
    : IRequestHandler<DeleteEventCommand, int>
{
    public async Task<int> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
    {
        var existingEvent = await _repository.GetByIdAsync(command.eventId);
        if (existingEvent is null) return 0;
        await _repository.DeleteAsync(existingEvent, cancellationToken);
        return existingEvent.EventId;
    }
}

