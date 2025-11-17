using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvents;

public record GetEventsQuery() : IRequest<List<EventResponse>>;

