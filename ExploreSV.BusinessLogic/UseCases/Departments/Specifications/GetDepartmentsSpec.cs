using Ardalis.Specification;
using ExploreSV.Entities;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Queries.Specifications;

public sealed class GetDepartmentsSpec : Specification<Department>
{
    public GetDepartmentsSpec(int departmentId = 0)
    {
        if (departmentId > 0)
            Query.Where(d => d.DepartmentId == departmentId);

        // Ordena los departamentos por nombre
        Query.OrderBy(d => d.DepartamentName);
    }

    public GetDepartmentsSpec(int skip, int take, int departmentId = 0)
        : this(departmentId) // Llama al constructor original
    {
        // Aplica paginación
        Query.Skip(skip).Take(take);
    }
}