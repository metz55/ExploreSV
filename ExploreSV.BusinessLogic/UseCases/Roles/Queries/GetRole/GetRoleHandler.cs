using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Queries.GetRole;

internal sealed class GetRoleHandler(IEfRepository<Role> _repository)
    : IRequestHandler<GetRoleQuery, RoleResponse>
{
    public async Task<RoleResponse> Handle(GetRoleQuery query, CancellationToken cancellationToken)
    {
        var role = await _repository.GetByIdAsync(query.RoleId, cancellationToken);

        if (role is null)
        {
            return new RoleResponse();
        }

        return role.Adapt<RoleResponse>();
    }
}
