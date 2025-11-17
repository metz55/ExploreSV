using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Commads.CreateRole;

internal sealed class CreateRoleHandler(IEfRepository<Role> _repository)
    : IRequestHandler<CreateRoleCommand, int>
{
    public async Task<int> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newRole = command.Request.Adapt<Role>();

            var createdRole = await _repository.AddAsync(newRole, cancellationToken);
            return createdRole.RoleId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}
