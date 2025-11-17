using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Events.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvents;
internal sealed class GetEventsHandler(IEfRepository<Event> _repository)
    : IRequestHandler<GetEventsQuery, List<EventResponse>>
{
    public async Task<List<EventResponse>> Handle(GetEventsQuery query, CancellationToken cancellationToken)
    {
        var events = await _repository.ListAsync(new GetEventWithTouristDestinationSpec(),cancellationToken);

        if (events == null && !events.Any())
        {
            return new List<EventResponse>();
        }
        return events.Adapt<List<EventResponse>>();
    }
}

