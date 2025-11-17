using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ExploreSV.BusinessLogic.UseCases.Events.Commands.CreateEvent;

internal sealed class CreateEventHandler(IEfRepository<Event> _repository) : IRequestHandler<CreateEventCommand, int>
{
    public async Task<int> Handle(CreateEventCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newEvent = command.Request.Adapt<Event>();

            var createEvent = await _repository.AddAsync(newEvent, cancellationToken);
            return createEvent.EventId;

        }

        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
