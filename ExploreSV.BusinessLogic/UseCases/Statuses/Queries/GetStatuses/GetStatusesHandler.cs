using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategories;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Statuses.Queries.GetStatuses;

internal sealed class GetStatusesHandler(IEfRepository<Status> _repository)
    : IRequestHandler<GetStatusesQuery, List<StatusResponse>>
{
    public async Task<List<StatusResponse>> Handle(GetStatusesQuery query, CancellationToken cancellationToken)
    {
        var statuses = await _repository.ListAsync(cancellationToken);
        if (statuses == null || !statuses.Any())
        {
            return new List<StatusResponse>();
        }
        return statuses.Adapt<List<StatusResponse>>();
    }
}
