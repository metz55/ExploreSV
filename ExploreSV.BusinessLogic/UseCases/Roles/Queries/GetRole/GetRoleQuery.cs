using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Queries.GetRole;

public record GetRoleQuery(int RoleId) : IRequest<RoleResponse>;
