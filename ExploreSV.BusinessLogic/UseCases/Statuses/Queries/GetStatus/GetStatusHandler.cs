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

namespace ExploreSV.BusinessLogic.UseCases.Statuses.Queries.GetStatus;

internal sealed class GetStatusHandler(IEfRepository<Status> _repository)
    : IRequestHandler<GetStatusQuery, StatusResponse>
{
    public async Task<StatusResponse> Handle(GetStatusQuery query, CancellationToken cancellationToken)
    {
        var status = await _repository.GetByIdAsync(query.statusId, cancellationToken);

        if (status is null)
        {
            return new StatusResponse();
        }
        return status.Adapt<StatusResponse>();
    }
}