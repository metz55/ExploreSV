using ExploreSV.BusinessLogic.DTOs;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Queries.GetRoles;

public record GetRolesQuery() : IRequest<List<RoleResponse>>;
