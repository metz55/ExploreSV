using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;
namespace ExploreSV.BusinessLogic.UseCases.Departments.Commands.CreateDepartment;

internal sealed class CreateDepartmentHandler(IEfRepository<Department> _repository) : IRequestHandler<CreateDepartmentCommand, int>
{
    public async Task<int> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var newDepartment = command.Request.Adapt<Department>();

            var createDepartment = await _repository.AddAsync(newDepartment, cancellationToken);

            return createDepartment.DepartmentId;
        }
        catch (Exception)
        {
            return 0;
            throw;
        }
    }
}