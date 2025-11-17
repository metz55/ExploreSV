using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.Utils;
using ExploreSV.BusinessLogic.UseCases.Departments.Queries.Specifications;
using ExploreSV.DataAccess.Interfaces;
using ExploreSV.Entities;
using Mapster;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Queries.GetDepartments;

internal sealed class GetDepartmentsHandler(IEfRepository<Department> _repository)
    : IRequestHandler<GetDepartmentsQuery, PaginatedList<DepartmentResponse>>
{
    public async Task<PaginatedList<DepartmentResponse>> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
    {
        // Obtener el total de departamentos
        var totalItems = await _repository.CountAsync(cancellationToken);
        // Obtener los departamentos paginados usando la especificación
        var departments = await _repository.ListAsync(
            new GetDepartmentsSpec(
                skip: (query.PageNumber - 1) * query.PageSize,
                take: query.PageSize
            ),
            cancellationToken
        );
        // Validar si hay datos
        if (departments == null || !departments.Any())
        {
            return new PaginatedList<DepartmentResponse>(
                new List<DepartmentResponse>(),
                0,
                query.PageNumber,
                query.PageSize
            );
        }
        // Adaptar a DTOs
        var departmentResponses = departments.Adapt<List<DepartmentResponse>>();
        // Retornar la lista paginada
        return new PaginatedList<DepartmentResponse>(
            departmentResponses,
            totalItems,
            query.PageNumber,
            query.PageSize
        );
    }
}