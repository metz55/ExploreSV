using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategory;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Events.Queries.GetEvent;

internal sealed class GetEventHandler(IEfRepository<Event> _repository)
    : IRequestHandler<GetEventQuery, EventResponse>
{
    public async Task<EventResponse> Handle(GetEventQuery query, CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(query.EventId, cancellationToken);

        if (category is null)
        {
            return new EventResponse();
        }
        return category.Adapt<EventResponse>();
    }
}
