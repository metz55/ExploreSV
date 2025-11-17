using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Commads.DeleteRole;

public record DeleteRoleCommand(int RoleId) : IRequest<int>;

