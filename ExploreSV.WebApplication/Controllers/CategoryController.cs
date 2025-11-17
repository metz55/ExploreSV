using ExploreSV.BusinessLogic.DTOs;
using ExploreSV.BusinessLogic.UseCases.Categories.Commands.CreateCategory;
using ExploreSV.BusinessLogic.UseCases.Categories.Commands.DeleteCategory;
using ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategory;
using ExploreSV.BusinessLogic.UseCases.Categories.Queries.GetCategories;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExploreSV.WebApplication.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 6)
        {
            var query = new GetCategoriesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            var categories = await _mediator.Send(query);
            return View(categories);
        }

        //GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: CategorytController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryRequest createCategoryRequest)
        {
            try
            {
                var result = await _mediator.Send(new CreateCategoryCommand(createCategoryRequest));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar guardar la nueva Categoria");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createCategoryRequest);
            }
        }

        //GET: CategoryController/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _mediator.Send(new GetCategoryQuery(id));
            return View(category);
        }

        //POST: CategoryController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CategoryResponse categoryResponse)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCategoryCommand(id));
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                    throw new Exception("Sucedio un error al intentar eliminar la Categoria");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(categoryResponse);
            }
        }
    }
}