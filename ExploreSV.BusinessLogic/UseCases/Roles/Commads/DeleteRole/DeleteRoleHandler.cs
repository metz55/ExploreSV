using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Roles.Commads.DeleteRole;

internal sealed class DeleteRoleHandler(IEfRepository<Role> _repository)
    : IRequestHandler<DeleteRoleCommand, int>
{
    public async Task<int> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
    {
        var existingRole = await _repository.GetByIdAsync(command.RoleId);

        if (existingRole is null) return 0;

        await _repository.DeleteAsync(existingRole, cancellationToken);

        return existingRole.RoleId;
    }
}
