using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Departments.Commands.CreateDepartment;
using ExploreSV.BusinessLogic.UseCases.Departments.Commands.DeleteDepartment;
using ExploreSV.BusinessLogic.UseCases.Departments.Queries.GetDepartment;
using ExploreSV.BusinessLogic.UseCases.Departments.Queries.GetDepartments;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6)
        {
            var query = new GetDepartmentsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var departments = await _mediator.Send(query);
            return View(departments);
        }

        //GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDepartmentRequest createDepartmentRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateDepartmentCommand(createDepartmentRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar el nuevo Departamento");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createDepartmentRequest);
            }
        }

        //GET: DepartmentController/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _mediator.Send(new GetDepartmentQuery(id));
            return View(department);
        }

        //POST: DepartmentController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DepartmentResponse departmentResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteDepartmentCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar el Departamento");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(departmentResponse);
            }
        }
    }
}