using MediatR;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Commands.DeleteDepartment;

public record DeleteDepartmentCommand(int DepartmentId) : IRequest<int>;