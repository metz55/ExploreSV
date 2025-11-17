using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Queries.GetDepartment;

internal sealed class GetDepartmentHandler(IEfRepository<Department> _repository) : IRequestHandler<GetDepartmentQuery, DepartmentResponse>
{
    public async Task<DepartmentResponse> Handle(GetDepartmentQuery query, CancellationToken cancellationToken)
    {
        var departments = await _repository.GetByIdAsync(query.DepartmentId, cancellationToken);

        if (departments is null)
        {
            return new DepartmentResponse();
        }

        return departments.Adapt<DepartmentResponse>();
    }
}