using ExploreSV.BusinessLogic.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreSV.BusinessLogic.UseCases.Departments.Commands.CreateDepartment;

public record CreateDepartmentCommand(CreateDepartmentRequest Request) : IRequest<int>;