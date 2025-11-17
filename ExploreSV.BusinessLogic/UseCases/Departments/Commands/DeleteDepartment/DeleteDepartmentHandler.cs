using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Commands.DeleteDepartment;

internal sealed class DeleteDepartmentHandler(IEfRepository<Department> _repository) : IRequestHandler<DeleteDepartmentCommand, int>
{
    public async Task<int> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var existingDepartment = await _repository.GetByIdAsync(command.DepartmentId);

        if (existingDepartment is null) return 0;

        await _repository.DeleteAsync(existingDepartment, cancellationToken);

        return existingDepartment.DepartmentId;
    }
}