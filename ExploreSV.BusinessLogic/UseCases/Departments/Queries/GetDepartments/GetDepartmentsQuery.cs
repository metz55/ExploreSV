using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.Utils;
using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Queries.GetDepartments;

public record GetDepartmentsQuery() : IRequest<PaginatedList<DepartmentResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 6;
}