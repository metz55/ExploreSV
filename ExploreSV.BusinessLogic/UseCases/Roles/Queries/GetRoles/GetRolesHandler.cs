using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Queries.GetRoles;

internal sealed class GetRolesHandler(IEfRepository<Role> _repository)
    : IRequestHandler<GetRolesQuery, List<RoleResponse>>
{
    public async Task<List<RoleResponse>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
    {
        var roles = await _repository.ListAsync(cancellationToken);

        if (roles == null || !roles.Any())
        {
            return new List<RoleResponse>();
        }
        return roles.Adapt<List<RoleResponse>>();

    }
}
